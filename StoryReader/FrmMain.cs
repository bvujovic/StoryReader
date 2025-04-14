using StoryReader.Classes;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace StoryReader
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                dgvVoices.DataSource = voices;
                dgvVoices.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvVoices.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvVoices.Columns[1].HeaderText = "Voice Name";
                dgvVoices.Columns[nameof(Voice.Volume)]!.ToolTipText
                    = string.Join(", ", VoiceHelpers.VolumeConstants) + Environment.NewLine + "123%";
                dgvVoices.Columns[nameof(Voice.Pitch)]!.ToolTipText
                    = string.Join(", ", VoiceHelpers.PitchConstants);
                dgvVoices.Columns[nameof(Voice.Rate)]!.ToolTipText
                    = string.Join(", ", VoiceHelpers.RateConstants) + Environment.NewLine + "123%";
                dgvVoices.Columns.RemoveAt(2);
                dgvVoices.Columns.Insert(2, CreateDropDownColumn("Color"));

                cmbVoices.Items.Clear();
                foreach (var v in speaker.Synth.GetInstalledVoices())
                    cmbVoices.Items.Add(v.VoiceInfo.Name);
                if (cmbVoices.Items.Count > 0)
                    cmbVoices.SelectedIndex = 0;
                IsNewCharOvertype = false;
                prevTxtInText = txtIn.Text;
                lblFileHeader.Text = "/";
                ttRegex.SetToolTip(cmbFind,
@"\[\d+\] - [1], [2], [3], etc. \d+ → Matches one or more digits (0-9).
\b means word boundary, so \bfox\b will only match ""fox"" and not ""firefox"".
^The	Matches ""The"" only if it is at the start of the text
dog$	\tMatches ""dog"" only if it is at the end of the text
fox.*dog	Finds ""fox jumps over the lazy dog"" .* for Anything");

                ds.ReadXml(dataSetFileName);
                numFontSize.Value = ds.Settings.ReadInt("FontSize", (int)numFontSize.Value);
                WindowState = ds.Settings.ReadBool("Maximized", false)
                    ? FormWindowState.Maximized : FormWindowState.Normal;
                if (WindowState == FormWindowState.Normal)
                {
                    var screen = Screen.PrimaryScreen!.WorkingArea;
                    Left = ds.Settings.ReadInt(nameof(Left), Left, it => it >= 0 && it < screen.Width);
                    Top = ds.Settings.ReadInt(nameof(Top), Top, it => it >= 0 && it <= screen.Height);
                    Width = ds.Settings.ReadInt(nameof(Width), Width, it => it > 100 && it <= screen.Width);
                    Height = ds.Settings.ReadInt(nameof(Height), Height, it => it > 100 && it <= screen.Height);
                }
                var json = ds.Settings.ReadString(nameof(SavedSearch.Searches), "[]");
                var theme = (AppTheme)ds.Settings.ReadInt(nameof(AppTheme), 0);
                if (theme == AppTheme.Light)
                    tsmiLightMode.PerformClick();
                else
                    if (theme == AppTheme.Dark)
                    tsmiDarkMode.PerformClick();
                SavedSearch.Searches = JsonSerializer.Deserialize<BindingList<SavedSearch>>(json)!;
                cmbFind.DataSource = SavedSearch.Searches;
                cmbFind.DisplayMember = nameof(SavedSearch.Find);
                cmbFind.SelectedIndex = -1;
                SavedSearch.Enabled = true;
                speaker.Synth.SpeakCompleted += Synth_SpeakCompleted;
                timKeyPresses.Start();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private static DataGridViewComboBoxColumn CreateDropDownColumn(string colName)
        {
            var col = new DataGridViewComboBoxColumn
            {
                DataPropertyName = colName,
                HeaderText = colName,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
            };
            col.Items.Add("");
            col.Items.AddRange(VoiceColor.AllColors.Select(it => it.Name).ToArray());
            return col;
        }

        private void DgvVoices_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var c = dgvVoices.Columns[e.ColumnIndex];
            if (c == null ||
                (c.Name != nameof(Voice.Volume) && c.Name != nameof(Voice.Pitch) && c.Name != nameof(Voice.Rate)))
                return;
            var s = e.FormattedValue?.ToString();
            if (VoiceHelpers.IsStringValid(s, c.Name))
                dgvVoices.Rows[e.RowIndex].ErrorText = string.Empty;
            else
            {
                e.Cancel = true;
                dgvVoices.Rows[e.RowIndex].ErrorText = "Invalid input!";
            }
        }

        private readonly Ds ds = new();
        private const string dataSetFileName = "ds.xml";

        // Ovo je osnova za reagovanje na pritiskanje tastera i u slucaju da prozor nije u fokusu
        //* https://stackoverflow.com/questions/63663036/how-to-receive-key-presses-when-out-of-focus-c-sharp-forms
        [DllImport("user32.dll")]
        static extern ushort GetAsyncKeyState(int vKey);

        public static bool IsKeyPushedDown(Keys vKey)
        {
            return 0 != (GetAsyncKeyState((int)vKey) & 0x8000);
        }

        private void TimKeyPresses_Tick(object sender, EventArgs e)
        {
            // Ctrl+Shift+Z - Play/Pause
            if (IsKeyPushedDown(Keys.ControlKey) && IsKeyPushedDown(Keys.ShiftKey) && IsKeyPushedDown(Keys.Z))
            {
                if (speaker.Synth.State == SynthesizerState.Ready)
                    btnSpeak.PerformClick();
                else
                    btnPauseResume.PerformClick();
            }
        }

        //private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.MediaPlayPause)
        //    {
        //        if (speaker.Synth.State == SynthesizerState.Ready)
        //            btnSpeak.PerformClick();
        //        else
        //            btnPauseResume.PerformClick();
        //    }
        //    if (e.KeyCode == Keys.MediaStop)
        //        btnStop.PerformClick();
        //}

        private readonly BindingList<Voice> voices = [];

        private readonly string headerSeparator = "*****";

        private string SpeechText
        {
            get
            {
                // ako je selektovan deo teksta - citaj taj deo
                if (txtIn.SelectionLength != 0)
                    return txtIn.SelectedText;
                // ako je kursor na kraju ili pocetku - citaj ceo tekst (od separatora zaglavlja)
                if (txtIn.SelectionStart == txtIn.TextLength || txtIn.SelectionStart == 0)
                {
                    var idx = txtIn.Text.IndexOf(headerSeparator + Environment.NewLine);
                    if (idx != -1)
                        return txtIn.Text[(idx + headerSeparator.Length)..];
                    else
                        return txtIn.Text;
                }
                // ako nije selektovano nista, niti je kursor na kraju teksta - citaj od kursora
                return txtIn.Text[txtIn.SelectionStart..];
            }
        }

        private readonly Story story = new();

        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            try
            {
                if (voices.Count == 0)
                    throw new Exception("You have to define at least one voice (default).");
                btnStop.PerformClick();
                var parts = TextFs.SplitSSMLs(SpeechText);
                story.Clear();
                foreach (var strPart in parts)
                {
                    var p = TextFs.CreatePart(strPart, voices);
                    story.AddPart(p);
                }

                var part = story.GetNextPart();
                if (part != null)
                {
                    speachStarted = true;
                    speaker.Synth.Volume = (int)numVolume.Value;
                    speaker.Synth.Rate = (int)numRate.Value;
                    speaker.Speak(part.ToSSML());
                }

                rtbOut.Rtf = story.ToRtf();

                //btnStop.PerformClick();
                //var parts = TextFs.SplitSSMLs(SpeechText);
                //TextFs.VoicesForCharacters(parts, voices);
                //TextFs.AddSSMLroot(parts);
                //txtOut.Clear();
                //speaker.Synth.Volume = (int)numVolume.Value;
                //speaker.Synth.Rate = (int)numRate.Value;
                //foreach (var p in parts)
                //{
                //    speaker.AddToSpeak(p);
                //    txtOut.Text += p + Environment.NewLine;
                //}
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Synth_SpeakCompleted(object? sender, SpeakCompletedEventArgs e)
        {
            var part = story.GetNextPart();
            if (part != null && speachStarted)
                speaker.Speak(part.ToSSML());
            else
                speachStarted = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // class Story: parts, [separators: space, newParagraph], [current]textReading, Read(idxChar/idxPart)
            // reakcija na dogadjaj kada je part procitan kako bi se znalo kada da se pokrene citanje novog part-a
            // metode: string ToRtf()

            // class Part: string text, Voice voice

            try
            {
                rtbOut.Rtf =
@"{\rtf1\ansi{\colortbl;\red128\green0\blue0; \red185\green105\blue145; \red240\green155\blue90; \red90\green64\blue64;}
This is \highlight1 red background text.\par
This is \highlight0 green background \highlight4 text.\par\par
This is \highlight3 blue background text.\par}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RtbOut_SelectionChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(rtbOut.SelectionBackColor);
            Debug.WriteLine(rtbOut.SelectionStart);
        }

        private readonly Speaker speaker = new();

        private bool speachStarted = false;

        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                speachStarted = false;
                var paused = speaker.Synth.State == SynthesizerState.Paused;
                speaker.Stop();
                if (paused)
                    btnPauseResume.PerformClick();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnChangeVoiceName_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbVoices.SelectedItem is string voiceName)
                {
                    var selCells = dgvVoices.SelectedCells;
                    var selVoice = selCells.Count == 0 || dgvVoices.Rows[selCells[0].RowIndex].IsNewRow
                        ? null : dgvVoices.Rows[selCells[0].RowIndex].DataBoundItem as Voice;

                    if (selVoice != null)
                    {
                        selVoice.VoiceName = voiceName;
                        dgvVoices.Refresh();
                    }
                    else if (!voices.Any(it => it.Character == Voice.Default))
                        voices.Add(new Voice
                        {
                            Character = Voice.Default,
                            VoiceName = voiceName,
                            Pitch = null,
                            Rate = null,
                            Volume = null,
                        });
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DisplayStatus(string s)
        {
            lblLastStatus.Text = s;
            lblLastStatus.BackColor = Color.Green;
            timStatus.Start();
        }

        private void TimStatus_Tick(object sender, EventArgs e)
        {
            timStatus.Stop();
            lblLastStatus.BackColor = SystemColors.Control;
        }

        private void TsmiFileSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFileChanged)
                {
                    DisplayFileName();
                    File.WriteAllText(fileName!, txtIn.Text);
                    DisplayStatus("File saved.");
                }
                else
                    throw new Exception("You have to open a file first.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void TxtIn_TextChanged(object sender, EventArgs e)
        {
            if (fileName != null && !lblFileHeader.Text.EndsWith('*'))
                lblFileHeader.Text += " *";
        }

        private void DisplayFileName()
        {
            if (fileName != null)
            {
                var fi = new FileInfo(fileName);
                lblFileHeader.Text = fi.Name;
            }
        }

        private string? fileName = null;

        private void TsmiFileOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtIn.Text = File.ReadAllText(fileName = ofd.FileName);
                    DisplayFileName();
                    ReadCharVoices();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ReadCharVoices()
        {
            voices.Clear();
            var idx = txtIn.Text.IndexOf(headerSeparator + Environment.NewLine);
            if (idx != -1)
            {
                var vcs = JsonSerializer.Deserialize<Voice[]>(txtIn.Text[..idx]);
                if (vcs == null)
                    return;
                foreach (var v in vcs)
                    voices.Add(v);
            }
        }

        private void BtnInsertVoicesJson_Click(object sender, EventArgs e)
        {
            try
            {
                var idx = txtIn.Text.IndexOf(headerSeparator);
                if (idx != -1)
                    txtIn.Text = txtIn.Text[(idx + headerSeparator.Length + 1)..];
                var json = JsonSerializer.Serialize(voices).Replace("},", "},\r\n");
                txtIn.Text = $"{json}\r\n{headerSeparator}\r\n{txtIn.Text}";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnApplyVoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVoices.CurrentRow?.DataBoundItem is not Voice v)
                    throw new Exception("You have to select a voice to be able to apply it to selected text.");
                ApplyVoice(v);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ApplyVoice(Voice v)
        {
            int idxStart, lenInsert;
            if (txtIn.SelectionLength == 0)
            {
                //var tweenQuot = false;
                if (txtIn.SelectionStart > 0 && txtIn.SelectionStart < txtIn.TextLength)
                {
                    idxStart = txtIn.Text.LastIndexOf('"', txtIn.SelectionStart - 1);
                    var idxEnd = txtIn.Text.IndexOf('"', txtIn.SelectionStart);
                    if (idxStart != -1 && idxEnd != -1)
                    {
                        //tweenQuot = true;
                        lenInsert = InsertVoiceTags(idxStart, idxEnd - idxStart + 1, v.Character);
                        //var s = txtIn.Text;
                        //s = s.Insert(idxEnd, "</voice>");
                        FocusOnText(idxStart, lenInsert);
                        return;
                    }
                }
                //if (!tweenQuot)
                throw new Exception("You have to select some text (or put cursor between quotation marks) to be able to apply selected voice.");
            }
            idxStart = txtIn.SelectionStart;
            var selLen = txtIn.SelectionLength;
            lenInsert = InsertVoiceTags(idxStart, selLen, v.Character);
            FocusOnText(idxStart, lenInsert);
        }

        private int InsertVoiceTags(int idxStart, int selLen, string character)
        {
            var s = txtIn.Text;
            s = s.Insert(idxStart + selLen, "</voice>");
            var startTag = $"<voice name=\"{character}\">";
            s = s.Insert(idxStart, startTag);
            txtIn.Text = s;
            return startTag.Length + selLen + "</voice>".Length;
        }

        private const int EM_LINESCROLL = 0x00B6;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private void FocusOnText(int idxStart, int length)
        {
            txtIn.Select(idxStart, length);
            txtIn.ScrollToCaret();
            var idxLine = txtIn.GetLineFromCharIndex(idxStart);
            if (idxLine > 8)
                _ = SendMessage(txtIn.Handle, EM_LINESCROLL, 0, 6);

            //var idxLine = txtIn.GetLineFromCharIndex(idxStart);
            //var dUp = idxLine >= 3 ? -3 : 0;
            //idxLine += dUp;
            //var changeLines = idxLine - idxLinePrev;
            //_ = SendMessage(txtIn.Handle, EM_LINESCROLL, 0, changeLines);
            //idxLinePrev = idxLine;
            txtIn.Focus();
        }

        private void BtnPauseResume_Click(object sender, EventArgs e)
        {
            var s = speaker.Synth;
            var paused = s.State == SynthesizerState.Paused;
            btnPauseResume.Text = paused ? "Pause" : "Play";
            btnPauseResume.BackColor = paused ? ThemeColors.LightBackColor : Color.LightBlue;
            btnPauseResume.ForeColor = ThemeColors.LightForeColor;
            if (paused)
                s.Resume();
            else
                s.Pause();
        }

        private void NumRate_ValueChanged(object sender, EventArgs e)
            => speaker.Synth.Rate = (int)numRate.Value;

        private void NumVolume_ValueChanged(object sender, EventArgs e)
            => speaker.Synth.Volume = (int)numVolume.Value;

        private void StoryTextHeader_Click(object sender, EventArgs e)
            => txtIn.Select();

        private void CmbFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtReplace.Text == "")
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtIn.Select();
            }
        }

        private void CmbFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFind.SelectedItem is SavedSearch ss && ss.Replace != null)
                txtReplace.Text = ss.Replace;
            else
                txtReplace.Text = "";
        }

        private void BtnFindNext_Click(object sender, EventArgs e)
        {
            try
            {
                var match = Regex.Match(txtIn.SelectedText, cmbFind.Text, RegexOptions.IgnoreCase);
                if (match.Success)
                    txtIn.SelectionStart++;
                //SavedSearch.Add(cmbFind.Text, txtReplace.Text);
                //cmbFind.SelectedIndex = 0;
            }
            catch { }
            FindText(true);
        }

        private void Search_Click(object sender, EventArgs e)
            => FindText(true);

        private void FindText(bool focus)
        {
            var str = cmbFind.Text;
            if (str.Length == 0)
            {
                lblSearchResults.Text = "";
                return;
            }
            try
            {
                if (focus)
                {
                    SavedSearch.Add(cmbFind.Text, txtReplace.Text);
                    SavedSearch.Enabled = false;
                    cmbFind.SelectedIndex = 0;
                    SavedSearch.Enabled = true;
                }
                var match = Regex.Match(txtIn.Text[txtIn.SelectionStart..], str, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    txtIn.Select(txtIn.SelectionStart + match.Index, match.Length);
                    lblSearchResults.Text = "✅";
                }
                else
                {
                    txtIn.Select(0, 0);
                    lblSearchResults.Text = "❌";
                }
                if (focus)
                    FocusOnText(txtIn.SelectionStart, txtIn.SelectionLength);
            }
            catch (Exception ex) { DisplayStatus(ex.Message); }
        }

        private void CmbFind_TextChanged(object sender, EventArgs e)
            => FindText(false);

        private void BtnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIn.SelectionLength == 0)
                    throw new Exception();
                var selStart = txtIn.SelectionStart;
                var s = txtIn.Text[..selStart];
                s += txtReplace.Text;
                s += txtIn.Text[(selStart + txtIn.SelectionLength)..];
                txtIn.Text = s;
                txtIn.Select(selStart + 1, 0);
                FindText(true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void TsmiRemoveDuplicateLetters_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIn.SelectionLength == 0)
                    throw new Exception("You have to select a part of text.");
                prevTxtInText = txtIn.Text;
                var idxStart = txtIn.SelectionStart;
                var idxEnd = idxStart + txtIn.SelectionLength;
                var chPrev = txtIn.Text[idxStart];
                var res = chPrev.ToString();
                for (int i = idxStart + 1; i < idxEnd; i++)
                {
                    var ch = txtIn.Text[i];
                    if (ch == '.' ||
                        ch != chPrev && char.ToLower(ch) != char.ToLower(chPrev))
                        res += chPrev = ch;
                }
                txtIn.Text = txtIn.Text[0..idxStart] + res + txtIn.Text[idxEnd..];
                FocusOnText(idxStart, res.Length);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool isNewCharOvertype;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsNewCharOvertype
        {
            get { return isNewCharOvertype; }
            set
            {
                isNewCharOvertype = value;
                tsmiInsertOvertype.Text = "New char: " + (value ? "Overtype" : "Insert");
            }
        }

        private void TsmiInsertOvertype_Click(object sender, EventArgs e)
        {
            IsNewCharOvertype = !IsNewCharOvertype;
            DisplayStatus(tsmiInsertOvertype.Text!);
        }

        private void DgvVoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // DoubleClick on any data row that is not new, Character column -> Click on Apply button
            if (e.RowIndex >= 0 && e.ColumnIndex == 0 && !dgvVoices.Rows[e.RowIndex].IsNewRow)
                btnApplyVoice.PerformClick();
        }

        private void TxtIn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var k = (int)e.KeyCode;
                if ((int)Keys.F1 <= k && k <= (int)Keys.F4)
                {
                    //e.SuppressKeyPress = true;
                    //e.Handled = true;
                    var idxVoice = k - (int)Keys.F1 + 1;
                    if (idxVoice < voices.Count)
                        ApplyVoice(voices[idxVoice]);
                    else
                        throw new Exception($"There is no voice number {idxVoice} - numbers start from 0. There are {voices.Count} voices.");
                }
            }
            catch (Exception ex) { DisplayStatus(ex.Message); }
        }

        private void TxtIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                prevTxtInText = txtIn.Text;
                var idxStart = txtIn.SelectionStart;
                if (IsNewCharOvertype && txtIn.SelectionLength == 0
                    && idxStart < txtIn.TextLength)
                {
                    var s = txtIn.Text.Remove(idxStart, 1);
                    s = s.Insert(idxStart, e.KeyChar.ToString());
                    txtIn.Text = s;
                    FocusOnText(idxStart, 1);
                    txtIn.Select(idxStart + 1, 0);
                    e.Handled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void TsmiAddSpaceAfterPunctuation_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIn.SelectionLength == 0)
                    throw new Exception("You have to select a part of text.");
                prevTxtInText = txtIn.Text;
                var idxStart = txtIn.SelectionStart;
                var chPrev = txtIn.SelectedText[0];
                var res = chPrev.ToString();
                var n = txtIn.SelectionLength;
                var isTag = false;
                for (int i = 1; i < n; i++)
                {
                    var ch = txtIn.SelectedText[i];
                    if (chPrev == '<' && ch == 'v' || chPrev == '<' && ch == '/')
                        isTag = true;
                    if (chPrev == '>')
                        isTag = false;

                    if (!isTag &&
                        char.IsPunctuation(chPrev) && !IsQuotation(chPrev) && !char.IsWhiteSpace(ch)
                        && (ch != '.' || chPrev != '.')
                        && (!IsQuotation(ch) || !IsQuotation(chPrev)))
                        res += " ";

                    res += chPrev = ch;
                }
                txtIn.Text = txtIn.Text[0..idxStart] + res
                    + txtIn.Text[(idxStart + n)..];
                FocusOnText(idxStart, res.Length);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private static bool IsQuotation(char c)
            => c == '"' || c == '\'';

        private void TsmiFileBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = ofd.InitialDirectory
                });
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Open Text/Story Folder"); }
        }

        private void NumFontSize_ValueChanged(object sender, EventArgs e)
        {
            txtIn.Font = rtbOut.Font = new Font(txtIn.Font.FontFamily, (int)numFontSize.Value);
        }

        private string prevTxtInText;

        private void TsmiEditUndo_Click(object sender, EventArgs e)
        {
            try
            {
                var idxStart = txtIn.SelectionStart;
                (prevTxtInText, txtIn.Text) = (txtIn.Text, prevTxtInText);
                txtIn.SelectionStart = idxStart;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public enum AppTheme
        {
            Light,
            Dark
        }

        public static class ThemeColors
        {
            public static Color LightBackColor => Color.White;
            public static Color LightForeColor => Color.Black;

            public static Color DarkBackColor => Color.FromArgb(30, 30, 30);
            public static Color DarkForeColor => Color.White;
        }

        private void TsmiViewMode_Click(object sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem tsmi)
                return;
            foreach (ToolStripMenuItem item in tsmiViewTheme.DropDownItems)
                item.Checked = ReferenceEquals(item, tsmi);

            var theme = AppTheme.Light;
            if (tsmi.Name == tsmiDarkMode.Name)
                theme = AppTheme.Dark;
            ApplyTheme(this, theme);
        }

        private HashSet<Control> ExcludedControls => [pnlStoryTextHeader, btnSpeak, btnStop, btnPauseResume];

        public void ApplyTheme(Control ctrl, AppTheme theme)
        {
            if (!ExcludedControls.Contains(ctrl))
            {
                var backColor = (theme == AppTheme.Dark) ? ThemeColors.DarkBackColor : ThemeColors.LightBackColor;
                var foreColor = (theme == AppTheme.Dark) ? ThemeColors.DarkForeColor : ThemeColors.LightForeColor;
                ctrl.BackColor = backColor;
                ctrl.ForeColor = foreColor;
                if (ReferenceEquals(ctrl, stripMenu))
                    foreach (ToolStripMenuItem item in stripMenu.Items)
                        ApplyThemeMenuItems(item, theme);
                if (ctrl == dgvVoices)
                    ApplyThemeDGV(dgvVoices, theme);
                else
                    foreach (Control child in ctrl.Controls)
                        ApplyTheme(child, theme);
            }
            else
                ctrl.ForeColor = ThemeColors.LightForeColor;
        }

        public static void ApplyThemeMenuItems(ToolStripMenuItem item, AppTheme theme)
        {
            var backColor = (theme == AppTheme.Dark) ? ThemeColors.DarkBackColor : ThemeColors.LightBackColor;
            var foreColor = (theme == AppTheme.Dark) ? Color.OrangeRed : ThemeColors.LightForeColor;
            item.BackColor = backColor;
            item.ForeColor = foreColor;
            foreach (ToolStripMenuItem it in item.DropDownItems)
                ApplyThemeMenuItems(it, theme);
        }

        private static void ApplyThemeDGV(DataGridView dgv, AppTheme theme)
        {
            dgv.BackgroundColor = (theme == AppTheme.Dark) ? ThemeColors.DarkBackColor : ThemeColors.LightBackColor;
            dgv.DefaultCellStyle.BackColor = (theme == AppTheme.Dark) ? Color.FromArgb(45, 45, 45) : Color.White;
            dgv.DefaultCellStyle.ForeColor = (theme == AppTheme.Dark) ? Color.White : Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = (theme == AppTheme.Dark) ? Color.FromArgb(70, 70, 70) : SystemColors.Highlight;
            dgv.DefaultCellStyle.SelectionForeColor = (theme == AppTheme.Dark) ? Color.White : SystemColors.HighlightText;
        }

        /// <summary>Is the text of a story changed.</summary>
        private bool IsFileChanged
            => fileName != null && lblFileHeader.Text.EndsWith('*');

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsFileChanged)
            {
                var res = MessageBox.Show("Do you want to save changes to your file?", "?"
                    , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel)
                    e.Cancel = true;
                if (res == DialogResult.Yes)
                    tsmiFileSave.PerformClick();
            }
            if (!e.Cancel)
            {
                ds.Settings.SaveSetting("FontSize", numFontSize.Value.ToString());
                var maximized = WindowState == FormWindowState.Maximized;
                ds.Settings.SaveSetting("Maximized", maximized.ToString());
                if (WindowState == FormWindowState.Normal)
                {
                    ds.Settings.SaveSetting(nameof(Width), Width.ToString());
                    ds.Settings.SaveSetting(nameof(Height), Height.ToString());
                    ds.Settings.SaveSetting(nameof(Left), Left.ToString());
                    ds.Settings.SaveSetting(nameof(Top), Top.ToString());
                }
                var theme = tsmiLightMode.Checked ? AppTheme.Light : AppTheme.Dark;
                ds.Settings.SaveSetting(nameof(AppTheme), ((int)theme).ToString());
                ds.Settings.SaveSetting(nameof(SavedSearch.Searches), JsonSerializer.Serialize(SavedSearch.Searches));
                ds.WriteXml(dataSetFileName);
            }
        }
    }
}
