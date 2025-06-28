using NAudio.Wave;
using StoryReader.Classes;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                IsNewCharOvertype = false;
                prevTxtInText = txtIn.Text;
                ttRegex.SetToolTip(cmbFind,
@"\[\d+\] - [1], [2], [3], etc. \d+ → Matches one or more digits (0-9).
\b means word boundary, so \bfox\b will only match ""fox"" and not ""firefox"".
^The	Matches ""The"" only if it is at the start of the text
dog$	\tMatches ""dog"" only if it is at the end of the text
fox.*dog	Finds ""fox jumps over the lazy dog"" .* for Anything");

                Utils.CalcIdxFolder();
                ds.ReadXml(dataSetFileName);
                numFontSize.Value = ds.Settings.ReadInt("FontSize", (int)numFontSize.Value);
                numRate.Value = ds.Settings.ReadInt("Rate", (int)numRate.Value);
                numVolume.Value = ds.Settings.ReadInt("Volume", (int)numVolume.Value);
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
                var json = ds.Settings.ReadString(nameof(SavedSearch.Searches), "[]")!;
                var theme = (AppTheme)ds.Settings.ReadInt(nameof(AppTheme), 0);
                if (theme == AppTheme.Light)
                    tsmiLightMode.PerformClick();
                else
                    if (theme == AppTheme.Dark)
                    tsmiDarkMode.PerformClick();
                var strVoices = ds.Settings.ReadString(nameof(AzureSounds.AzureVoices), string.Empty)!;
                AzureSounds.AzureVoices = strVoices.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                LoadAllVoices();

                ofd.InitialDirectory = Utils.GetStoriesFolderName();
                fileName = ds.Settings.ReadString(nameof(fileName));
                LoadFile(fileName);
                SavedSearch.Searches = JsonSerializer.Deserialize<BindingList<SavedSearch>>(json)!;
                cmbFind.DataSource = SavedSearch.Searches;
                cmbFind.DisplayMember = nameof(SavedSearch.Find);
                cmbFind.SelectedIndex = -1;
                SavedSearch.Enabled = true;
                //speaker.Synth.SpeakCompleted += Synth_SpeakCompleted;
                player.Init();
                player.Stopped += Player_Stopped;
                timKeyPresses.Start();
                isFormLoading = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadAllVoices()
        {
            cmbVoices.Items.Clear();
            // Voices installed on system: Settings / Time&language / Speech / Voices
            foreach (var v in player.GetInstalledVoices())
                cmbVoices.Items.Add(v.VoiceInfo.Name);
            // Azure voices
            foreach (var v in AzureSounds.AzureVoices!)
                cmbVoices.Items.Add(v);
            if (cmbVoices.Items.Count > 0)
                cmbVoices.SelectedIndex = 0;
        }

        private bool isFormLoading = true;

        private static DataGridViewComboBoxColumn CreateDropDownColumn(string colName)
        {
            var col = new DataGridViewComboBoxColumn
            {
                DataPropertyName = colName,
                HeaderText = colName,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
            };
            col.Items.Add("");
            col.Items.AddRange(VoiceColorHelpers.AllColors.Select(it => it.Name).ToArray());
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
                var isNumber = int.TryParse(s, out int x);
                if (isNumber && (c.Name == nameof(Voice.Volume) || c.Name == nameof(Voice.Rate)))
                {
                    dgvVoices.Rows[e.RowIndex].ErrorText = string.Empty;
                    if (dgvVoices.CurrentRow?.DataBoundItem is Voice v)
                    {
                        dgvVoices_ValidVoice = v;
                        dgvVoices_ValidColumn = c.Name;
                    }
                    else
                        dgvVoices_ValidVoice = null;
                }
                else
                {
                    e.Cancel = true;
                    dgvVoices.Rows[e.RowIndex].ErrorText = "Invalid input!";
                }
            }
        }

        private Voice? dgvVoices_ValidVoice = null;
        private string dgvVoices_ValidColumn;

        private void DgvVoices_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVoices_ValidVoice != null)
            {
                if (dgvVoices_ValidColumn == nameof(Voice.Volume))
                    dgvVoices_ValidVoice.Volume += "%";
                if (dgvVoices_ValidColumn == nameof(Voice.Rate))
                    dgvVoices_ValidVoice.Rate += "%";
                dgvVoices_ValidVoice = null;
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
            if ((DateTime.Now - lastTimKeyPress).TotalMilliseconds < 500)
                return;
            // Ctrl+Shift+Z - Play/Pause
            // if (IsKeyPushedDown(Keys.ControlKey) && IsKeyPushedDown(Keys.ShiftKey) && IsKeyPushedDown(Keys.Z)
            if (IsKeyPushedDown(Keys.F5))
            {
                lastTimKeyPress = DateTime.Now;
                //if (speaker.Synth.State == SynthesizerState.Ready)
                if (player.State == PlayerState.Ready)
                    btnSpeak.PerformClick();
                else
                    btnPauseResume.PerformClick();
            }
            if (IsKeyPushedDown(Keys.F6))
            {
                lastTimKeyPress = DateTime.Now;
                btnBackward.PerformClick();
            }
            if (IsKeyPushedDown(Keys.F7))
            {
                lastTimKeyPress = DateTime.Now;
                btnForward.PerformClick();
            }

            //* PerformClick() is executed only once per key press - no matter how long press lasts
            //* private bool keyPushedF6 = false;
            //
            //if (IsKeyPushedDown(Keys.F6))
            //{
            //    if (!keyPushedF6)
            //        btnBackward.PerformClick();
            //    keyPushedF6 = true;
            //}
            //else
            //    keyPushedF6 = false;
        }


        private DateTime lastTimKeyPress = DateTime.MinValue;

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

        private async void BtnSpeak_Click(object sender, EventArgs e)
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
                    var ss = TextFs.SplitSentences(p.Text);
                    foreach (var s in ss)
                        story.AddPart(new Part { Text = s, Voice = p.Voice });
                }

                var part = story.GetNextPart();
                if (part != null)
                {
                    player.Volume = (int)numVolume.Value;
                    player.Rate = (int)numRate.Value;
                    await Speak(part);
                }
                DisplayStory();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DisplayStory()
        {
            var rtf = story.ToRtf();
            //Debug.WriteLine(rtf);
            rtbOut.Rtf = rtf;

            rtbOut.Select(0, 1);
            //Debug.WriteLine(rtbOut.SelectedRtf.Contains("ul"));
            if (!story.IsCurrentPartFirst && rtbOut.SelectedRtf.Contains("ul"))
            {
                rtbOut.Font = new Font(txtIn.Font.FontFamily, (float)numFontSize.Value + 0.1f);
                //rtbOut.Font = new Font(txtIn.Font.FontFamily, (int)numFontSize.Value);
            }
        }

        private async void Player_Stopped(object? sender, EventArgs e)
        {
            if (player.StoppedByUser)
                return;
            var part = story.GetNextPart();
            if (part != null)
            {
                await Speak(part);
                rtbOut.BeginInvoke((MethodInvoker)delegate { DisplayStory(); });
            }
            else
            {
                player.Stop();
                story.SetCurrentPartNull();
                DisplayStory();
            }
        }

        private readonly Player player = new();

        private async Task Speak(Part part)
        {
            try
            {
                await player.Play(part, (int)numVolume.Value, (int)numRate.Value);
                lastSentenceBack = DateTime.Now;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private DateTime lastSentenceBack = DateTime.MinValue;

        private async void BtnBackward_Click(object sender, EventArgs e)
        {
            try
            {
                player.Stop();
                var part = ((DateTime.Now - lastSentenceBack).TotalSeconds < 2)
                    ? story.GetPrevPart() : story.CurrentPart;
                if (part != null)
                {
                    DisplayStory();
                    await Speak(part);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void BtnForward_Click(object sender, EventArgs e)
        {
            //rtbOut.Rtf = @"{\rtf1\ansi{\colortbl;\red255\green255\blue255;\red255\green0\blue0;\red0\green255\blue0;\red0\green0\blue255;}
            //This is \highlight1 red background text.\par
            //This is \highlight2 green \ul background\ulnone  text.\par
            //This is \highlight3 blue background text.\par}";

            player.Stop();
            var part = story.GetNextPart();
            if (part != null)
            {
                DisplayStory();
                await Speak(part);
            }
        }

        //private readonly Speaker speaker = new();

        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                player.Stop();
                story.SetCurrentPartNull();
                DisplayStory();
                //if (speaker.Synth.State == SynthesizerState.Paused)
                if (player.State == PlayerState.Paused)
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
                            Color = VoiceColorHelpers.Default.Name,
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
                if (isFileChanged)
                {
                    File.WriteAllText(fileName!, txtIn.Text);
                    DisplayStatus("File saved.");
                    //DisplayFileName();
                    isFileChanged = false;
                    DisplayCaption();
                }
                else
                    throw new Exception("You have to open a file first.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void TxtIn_TextChanged(object sender, EventArgs e)
        {
            //if (fileName != null && !lblFileHeader.Text.EndsWith('*'))
            //    lblFileHeader.Text += " *";
            if (fileName != null && !isFileChanged)
            {
                isFileChanged = true;
                DisplayCaption();
            }
        }

        //private void DisplayFileName()
        //{
        //    if (fileName != null)
        //    {
        //        var fi = new FileInfo(fileName);
        //        lblFileHeader.Text = fi.Name;
        //    }
        //    else
        //        lblFileHeader.Text = "";
        //}

        /// <summary>Display application title/caption: file name (if opened) - application name</summary>
        private void DisplayCaption()
        {
            if (string.IsNullOrEmpty(fileName))
                Text = AppName;
            else
            {
                var fi = new FileInfo(fileName);
                Text = $"{(isFileChanged ? "*" : "")}{fi.Name} - {AppName}";
            }
        }

        private const string AppName = "Story Reader";
        private string? fileName = null;
        /// <summary>Is the text of a story changed.</summary>
        private bool isFileChanged = false;

        private void TsmiFileOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    LoadFile(ofd.FileName);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadFile(string? file)
        {
            fileName = file;
            txtIn.Text = (file != null) ? File.ReadAllText(file) : "";
            txtIn.Select(0, 0);
            rtbOut.Clear();
            ds.Settings.SaveSetting(nameof(fileName), file);
            isFileChanged = false;
            DisplayCaption();
            ReadCharVoices();
        }

        private void TsmiFileClose_Click(object sender, EventArgs e)
        {
            try { LoadFile(null); }
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
                if (txtIn.SelectionStart > 0 && txtIn.SelectionStart < txtIn.TextLength)
                {
                    idxStart = txtIn.Text.LastIndexOf('"', txtIn.SelectionStart - 1);
                    var idxEnd = txtIn.Text.IndexOf('"', txtIn.SelectionStart);
                    if (idxStart != -1 && idxEnd != -1)
                    {
                        lenInsert = InsertVoiceTags(idxStart, idxEnd - idxStart + 1, v.Character);
                        FocusOnText(idxStart, lenInsert);
                        return;
                    }
                }
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
            //var s = speaker.Synth;
            //var paused = s.State == SynthesizerState.Paused;
            var paused = player.State == PlayerState.Paused;
            btnPauseResume.Text = paused ? "Pause" : "Play";
            btnPauseResume.BackColor = paused ? ThemeColors.LightBackColor : Color.LightBlue;
            btnPauseResume.ForeColor = ThemeColors.LightForeColor;
            if (paused)
                player.Resume();
            else
                player.Pause();
            //if (paused)
            //    s.Resume();
            //else
            //    s.Pause();
        }

        private void NumRate_ValueChanged(object sender, EventArgs e)
            //=> speaker.Synth.Rate = (int)numRate.Value;
            => player.Rate = (int)numRate.Value;

        private void NumVolume_ValueChanged(object sender, EventArgs e)
            //=> speaker.Synth.Volume = (int)numVolume.Value;
            => player.Volume = (int)numVolume.Value;

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

        private void TsmiFind_RemoveSearch_Click(object sender, EventArgs e)
        {
            if (cmbFind.SelectedItem is SavedSearch ss)
                SavedSearch.Remove(ss);
        }

        private void BtnFindNext_Click(object sender, EventArgs e)
        {
            try
            {
                var match = Regex.Match(txtIn.SelectedText, cmbFind.Text, RegexOptions.IgnoreCase);
                if (match.Success)
                    txtIn.SelectionStart++;
            }
            catch { }
            FindText(true);
        }

        private void Search_Click(object sender, EventArgs e)
            => FindText(true);

        private void FindText(bool focus)
        {
            if (isFormLoading)
                return;
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

        private void TsmiOut_FindSelection_Click(object sender, EventArgs e)
        {
            var match = Regex.Match(txtIn.Text, rtbOut.SelectedText, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                txtIn.Select(match.Index, match.Length);
                FocusOnText(txtIn.SelectionStart, txtIn.SelectionLength);
            }
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
            DisplayStory();
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

        private HashSet<Control> ExcludedControls => [btnSpeak, btnStop, btnPauseResume];

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

        ///// <summary>Is the text of a story changed.</summary>
        //private bool IsFileChanged
        //    => fileName != null && lblFileHeader.Text.EndsWith('*');

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isFileChanged)
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
                ds.Settings.SaveSetting("Rate", numRate.Value.ToString());
                ds.Settings.SaveSetting("Volume", numVolume.Value.ToString());
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
                ds.Settings.SaveSetting(nameof(AzureSounds.AzureVoices), string.Join(Environment.NewLine, AzureSounds.AzureVoices));
                ds.WriteXml(dataSetFileName);
            }
        }

        private void CtxOut_Opening(object sender, CancelEventArgs e)
        {
            tsmiOut_FindSelection.Enabled = rtbOut.SelectionLength > 0;
        }

        private void TsmiEditRemoveLineBreaks_Click(object sender, EventArgs e)
        {
            try
            {
                // remove new lines that cut sentences (made in PDF)
                if (txtIn.SelectionLength == 0)
                    throw new Exception("You have to select some text to be able to use this function.");
                var sentenceSeparators = new char[] { '.', '?', '!', ':', ';' };
                var s = txtIn.SelectedText;
                var idxStart = 0;
                while (true)
                {
                    var idxNewLine = s.IndexOf(Environment.NewLine, idxStart);
                    if (idxNewLine == -1)
                        break;
                    var idx = idxNewLine;
                    while (idx-- >= 0 && char.IsWhiteSpace(s[idx]))
                        ;
                    if (!sentenceSeparators.Contains(s[idx]))
                    {
                        s = s[..(idx + 1)] + " " + s[(idxNewLine + 2)..];
                        idxStart = idxNewLine + 1;
                    }
                    else
                        idxStart = idxNewLine + 2;
                }
                txtIn.Text = txtIn.Text[..txtIn.SelectionStart] + s
                    + txtIn.Text[(txtIn.SelectionStart + txtIn.SelectionLength)..];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        //private WaveOutEvent? waveOutDevice;
        //private AudioFileReader? audioFileReader;

        private void BtnMp3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (waveOutDevice == null)
            //    {
            //        waveOutDevice = new WaveOutEvent();
            //        waveOutDevice.PlaybackStopped += OnPlaybackStopped; 
            //        var mp3FilePath = "c:\\Users\\sosos\\Music\\Hurricane - Favorito.mp3";
            //        audioFileReader = new AudioFileReader(mp3FilePath);
            //        waveOutDevice.Init(audioFileReader);
            //    }
            //    waveOutDevice.Play(); // Start or resume playback
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void TsmiVoicesAzureVoices_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FrmAzureVoices
                {
                    Voices = string.Join(Environment.NewLine, AzureSounds.AzureVoices!)
                };
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    AzureSounds.AzureVoices = frm.Voices.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                    LoadAllVoices();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        //private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        //{
        //    if (audioFileReader != null)
        //    {
        //        audioFileReader.Dispose();
        //        audioFileReader = null;
        //    }
        //    if (waveOutDevice != null)
        //    {
        //        waveOutDevice.Dispose();
        //        waveOutDevice = null;
        //    }
        //    if (e.Exception != null)
        //        MessageBox.Show($"Playback error: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        //* example for WebView2 as control that displays 'Out' text
        //                string html = @"
        //<!DOCTYPE html>
        //<html>
        //<head>
        //  <meta charset='UTF-8'>
        //  <style>
        //    body { font-family: 'Segoe UI'; font-size: 21px; color: white; background-color: #1e1e1e; padding: 20px; }
        //  </style>
        //<script>
        //function underlineById(id) {
        //  document.querySelectorAll('span').forEach(span => {    span.style.textDecoration = 'none';  });
        //  const el = document.getElementById(id);
        //  if (el)
        //    el.style.textDecoration = 'underline';
        //}
        //</script>
        //</head>
        //<body>
        //<span id='1'>One</span>
        //<span id='2'>Two</span>
        //<span id='3'>Three</span>
        //  <p>This is a <u>very important</u> sentence.</p>
        //  <p>Another: <span style='text-decoration: underline;'>highlighted part</span>.</p>
        //</body>
        //</html>
        //";
        //                await webViewOut.EnsureCoreWebView2Async();
        //                webViewOut.NavigateToString(html);
        //try
        //{
        //    webViewOut.CoreWebView2?.ExecuteScriptAsync($"underlineById('{numRate.Value}')");
        //}
        //catch (Exception ex) { MessageBox.Show(ex.Message); }

    }
}
