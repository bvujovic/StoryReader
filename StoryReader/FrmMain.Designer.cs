namespace StoryReader
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Label label2;
            Label label1;
            Label label3;
            scMain = new SplitContainer();
            txtIn = new TextBox();
            pnlStoryTextHeader = new Panel();
            lblFileHeader = new Label();
            txtOut = new TextBox();
            numFontSize = new NumericUpDown();
            btnPauseResume = new StoryReader.Controls.UcButton();
            numVolume = new NumericUpDown();
            numRate = new NumericUpDown();
            btnStop = new StoryReader.Controls.UcButton();
            btnSpeak = new StoryReader.Controls.UcButton();
            ofd = new OpenFileDialog();
            stripStatus = new StatusStrip();
            lblLastStatus = new ToolStripStatusLabel();
            stripMenu = new MenuStrip();
            tsmiFile = new ToolStripMenuItem();
            tsmiFileOpen = new ToolStripMenuItem();
            tsmiFileSave = new ToolStripMenuItem();
            tsmiFileBrowse = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            tsmiRemoveDuplicateLetters = new ToolStripMenuItem();
            tsmiInsertOvertype = new ToolStripMenuItem();
            tsmiAddSpaceAfterPunctuation = new ToolStripMenuItem();
            tsmiEditUndo = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            tsmiViewTheme = new ToolStripMenuItem();
            tsmiLightMode = new ToolStripMenuItem();
            tsmiDarkMode = new ToolStripMenuItem();
            timStatus = new System.Windows.Forms.Timer(components);
            ttRegex = new ToolTip(components);
            timKeyPresses = new System.Windows.Forms.Timer(components);
            cmbVoices = new ComboBox();
            btnChangeVoiceName = new StoryReader.Controls.UcButton();
            btnInsertVoicesJson = new StoryReader.Controls.UcButton();
            dgvVoices = new DataGridView();
            btnApplyVoice = new StoryReader.Controls.UcButton();
            lblSearchResults = new Label();
            txtReplace = new TextBox();
            btnFindNext = new StoryReader.Controls.UcButton();
            btnReplace = new StoryReader.Controls.UcButton();
            cmbFind = new ComboBox();
            pnlTop = new Panel();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)scMain).BeginInit();
            scMain.Panel1.SuspendLayout();
            scMain.Panel2.SuspendLayout();
            scMain.SuspendLayout();
            pnlStoryTextHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFontSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRate).BeginInit();
            stripStatus.SuspendLayout();
            stripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVoices).BeginInit();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(979, 40);
            label2.Name = "label2";
            label2.Size = new Size(30, 20);
            label2.TabIndex = 7;
            label2.Text = "Vol";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(979, 7);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 8;
            label1.Text = "Rate";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(980, 89);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 13;
            label3.Text = "Font";
            // 
            // scMain
            // 
            scMain.Dock = DockStyle.Fill;
            scMain.Font = new Font("Segoe UI", 11.25F);
            scMain.Location = new Point(0, 159);
            scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            scMain.Panel1.Controls.Add(txtIn);
            scMain.Panel1.Controls.Add(pnlStoryTextHeader);
            // 
            // scMain.Panel2
            // 
            scMain.Panel2.Controls.Add(txtOut);
            scMain.Size = new Size(1236, 414);
            scMain.SplitterDistance = 616;
            scMain.TabIndex = 0;
            // 
            // txtIn
            // 
            txtIn.Dock = DockStyle.Fill;
            txtIn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIn.Location = new Point(0, 27);
            txtIn.MaxLength = 100000;
            txtIn.Multiline = true;
            txtIn.Name = "txtIn";
            txtIn.ScrollBars = ScrollBars.Vertical;
            txtIn.Size = new Size(616, 387);
            txtIn.TabIndex = 1;
            txtIn.Text = "<voice name=\"cousin\">\"Looks like it's your turn to do it\"</voice> my cousin said to me with a smile";
            txtIn.TextChanged += TxtIn_TextChanged;
            txtIn.KeyDown += TxtIn_KeyDown;
            txtIn.KeyPress += TxtIn_KeyPress;
            // 
            // pnlStoryTextHeader
            // 
            pnlStoryTextHeader.BackColor = Color.SkyBlue;
            pnlStoryTextHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlStoryTextHeader.Controls.Add(lblFileHeader);
            pnlStoryTextHeader.Dock = DockStyle.Top;
            pnlStoryTextHeader.Location = new Point(0, 0);
            pnlStoryTextHeader.Name = "pnlStoryTextHeader";
            pnlStoryTextHeader.Size = new Size(616, 27);
            pnlStoryTextHeader.TabIndex = 2;
            pnlStoryTextHeader.Click += StoryTextHeader_Click;
            // 
            // lblFileHeader
            // 
            lblFileHeader.AutoSize = true;
            lblFileHeader.Dock = DockStyle.Left;
            lblFileHeader.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFileHeader.Location = new Point(0, 0);
            lblFileHeader.Margin = new Padding(0);
            lblFileHeader.Name = "lblFileHeader";
            lblFileHeader.Padding = new Padding(2);
            lblFileHeader.Size = new Size(75, 27);
            lblFileHeader.TabIndex = 0;
            lblFileHeader.Text = "story.txt";
            lblFileHeader.Click += StoryTextHeader_Click;
            // 
            // txtOut
            // 
            txtOut.Dock = DockStyle.Fill;
            txtOut.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOut.Location = new Point(0, 0);
            txtOut.Multiline = true;
            txtOut.Name = "txtOut";
            txtOut.ScrollBars = ScrollBars.Vertical;
            txtOut.Size = new Size(616, 414);
            txtOut.TabIndex = 2;
            // 
            // numFontSize
            // 
            numFontSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numFontSize.Location = new Point(1024, 87);
            numFontSize.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numFontSize.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            numFontSize.Name = "numFontSize";
            numFontSize.Size = new Size(54, 27);
            numFontSize.TabIndex = 14;
            numFontSize.Value = new decimal(new int[] { 12, 0, 0, 0 });
            numFontSize.ValueChanged += NumFontSize_ValueChanged;
            // 
            // btnPauseResume
            // 
            btnPauseResume.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPauseResume.Location = new Point(1149, 71);
            btnPauseResume.Name = "btnPauseResume";
            btnPauseResume.Size = new Size(75, 28);
            btnPauseResume.TabIndex = 12;
            btnPauseResume.Text = "Pause";
            btnPauseResume.ToolTipText = "Play/Pause current speech";
            btnPauseResume.UseVisualStyleBackColor = true;
            btnPauseResume.Click += BtnPauseResume_Click;
            // 
            // numVolume
            // 
            numVolume.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numVolume.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numVolume.Location = new Point(1024, 38);
            numVolume.Name = "numVolume";
            numVolume.Size = new Size(54, 27);
            numVolume.TabIndex = 9;
            numVolume.Value = new decimal(new int[] { 65, 0, 0, 0 });
            numVolume.ValueChanged += NumVolume_ValueChanged;
            // 
            // numRate
            // 
            numRate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numRate.Location = new Point(1024, 5);
            numRate.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numRate.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            numRate.Name = "numRate";
            numRate.Size = new Size(54, 27);
            numRate.TabIndex = 10;
            numRate.ValueChanged += NumRate_ValueChanged;
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStop.BackColor = Color.LightCoral;
            btnStop.Location = new Point(1149, 37);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 28);
            btnStop.TabIndex = 6;
            btnStop.Text = "Don't";
            btnStop.ToolTipText = "Stop current speech";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += BtnStop_Click;
            // 
            // btnSpeak
            // 
            btnSpeak.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSpeak.BackColor = Color.LightGreen;
            btnSpeak.Location = new Point(1149, 4);
            btnSpeak.Name = "btnSpeak";
            btnSpeak.Size = new Size(75, 28);
            btnSpeak.TabIndex = 5;
            btnSpeak.Text = "Speak";
            btnSpeak.ToolTipText = "Play speech for selected text";
            btnSpeak.UseVisualStyleBackColor = false;
            btnSpeak.Click += BtnSpeak_Click;
            // 
            // ofd
            // 
            ofd.AddToRecent = false;
            ofd.Filter = "Test files|*.txt|Html files|*.htm*|All files|*.*";
            ofd.InitialDirectory = "c:\\Users\\bvnet\\OneDrive\\Citanje\\_Wcf, Wpf, SOA\\cepri\\_StoryReader\\";
            // 
            // stripStatus
            // 
            stripStatus.Items.AddRange(new ToolStripItem[] { lblLastStatus });
            stripStatus.Location = new Point(0, 573);
            stripStatus.Name = "stripStatus";
            stripStatus.Size = new Size(1236, 22);
            stripStatus.TabIndex = 1;
            stripStatus.Text = "statusStrip1";
            // 
            // lblLastStatus
            // 
            lblLastStatus.Name = "lblLastStatus";
            lblLastStatus.Size = new Size(12, 17);
            lblLastStatus.Text = "/";
            // 
            // stripMenu
            // 
            stripMenu.Items.AddRange(new ToolStripItem[] { tsmiFile, editToolStripMenuItem, viewToolStripMenuItem });
            stripMenu.Location = new Point(0, 0);
            stripMenu.Name = "stripMenu";
            stripMenu.Size = new Size(1236, 24);
            stripMenu.TabIndex = 2;
            stripMenu.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            tsmiFile.DropDownItems.AddRange(new ToolStripItem[] { tsmiFileOpen, tsmiFileSave, tsmiFileBrowse });
            tsmiFile.Name = "tsmiFile";
            tsmiFile.Size = new Size(37, 20);
            tsmiFile.Text = "File";
            // 
            // tsmiFileOpen
            // 
            tsmiFileOpen.Name = "tsmiFileOpen";
            tsmiFileOpen.ShortcutKeys = Keys.Control | Keys.O;
            tsmiFileOpen.Size = new Size(155, 22);
            tsmiFileOpen.Text = "Open...";
            tsmiFileOpen.ToolTipText = "Open text/story file";
            tsmiFileOpen.Click += TsmiFileOpen_Click;
            // 
            // tsmiFileSave
            // 
            tsmiFileSave.Name = "tsmiFileSave";
            tsmiFileSave.ShortcutKeys = Keys.Control | Keys.S;
            tsmiFileSave.Size = new Size(155, 22);
            tsmiFileSave.Text = "Save";
            tsmiFileSave.ToolTipText = "Save changes to opened text/story";
            tsmiFileSave.Click += TsmiFileSave_Click;
            // 
            // tsmiFileBrowse
            // 
            tsmiFileBrowse.Name = "tsmiFileBrowse";
            tsmiFileBrowse.Size = new Size(155, 22);
            tsmiFileBrowse.Text = "Browse...";
            tsmiFileBrowse.Click += TsmiFileBrowse_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiRemoveDuplicateLetters, tsmiInsertOvertype, tsmiAddSpaceAfterPunctuation, tsmiEditUndo });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // tsmiRemoveDuplicateLetters
            // 
            tsmiRemoveDuplicateLetters.Name = "tsmiRemoveDuplicateLetters";
            tsmiRemoveDuplicateLetters.ShortcutKeys = Keys.Control | Keys.D;
            tsmiRemoveDuplicateLetters.Size = new Size(265, 22);
            tsmiRemoveDuplicateLetters.Text = "Remove duplicate letters";
            tsmiRemoveDuplicateLetters.Click += TsmiRemoveDuplicateLetters_Click;
            // 
            // tsmiInsertOvertype
            // 
            tsmiInsertOvertype.Name = "tsmiInsertOvertype";
            tsmiInsertOvertype.ShortcutKeys = Keys.Control | Keys.I;
            tsmiInsertOvertype.Size = new Size(265, 22);
            tsmiInsertOvertype.Text = "New char: Insert";
            tsmiInsertOvertype.ToolTipText = "Click to change the way new character is placed in text: Insert<->Overtype";
            tsmiInsertOvertype.Click += TsmiInsertOvertype_Click;
            // 
            // tsmiAddSpaceAfterPunctuation
            // 
            tsmiAddSpaceAfterPunctuation.Name = "tsmiAddSpaceAfterPunctuation";
            tsmiAddSpaceAfterPunctuation.ShortcutKeys = Keys.Control | Keys.P;
            tsmiAddSpaceAfterPunctuation.Size = new Size(265, 22);
            tsmiAddSpaceAfterPunctuation.Text = "Add space after punctuation";
            tsmiAddSpaceAfterPunctuation.Click += TsmiAddSpaceAfterPunctuation_Click;
            // 
            // tsmiEditUndo
            // 
            tsmiEditUndo.Name = "tsmiEditUndo";
            tsmiEditUndo.ShortcutKeys = Keys.Control | Keys.Z;
            tsmiEditUndo.Size = new Size(265, 22);
            tsmiEditUndo.Text = "Undo";
            tsmiEditUndo.Click += TsmiEditUndo_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiViewTheme });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // tsmiViewTheme
            // 
            tsmiViewTheme.DropDownItems.AddRange(new ToolStripItem[] { tsmiLightMode, tsmiDarkMode });
            tsmiViewTheme.Name = "tsmiViewTheme";
            tsmiViewTheme.Size = new Size(111, 22);
            tsmiViewTheme.Text = "Theme";
            // 
            // tsmiLightMode
            // 
            tsmiLightMode.Checked = true;
            tsmiLightMode.CheckOnClick = true;
            tsmiLightMode.CheckState = CheckState.Checked;
            tsmiLightMode.Name = "tsmiLightMode";
            tsmiLightMode.Size = new Size(135, 22);
            tsmiLightMode.Text = "Light Mode";
            tsmiLightMode.Click += TsmiViewMode_Click;
            // 
            // tsmiDarkMode
            // 
            tsmiDarkMode.CheckOnClick = true;
            tsmiDarkMode.Name = "tsmiDarkMode";
            tsmiDarkMode.Size = new Size(135, 22);
            tsmiDarkMode.Text = "Dark Mode";
            tsmiDarkMode.Click += TsmiViewMode_Click;
            // 
            // timStatus
            // 
            timStatus.Interval = 1000;
            timStatus.Tick += TimStatus_Tick;
            // 
            // ttRegex
            // 
            ttRegex.AutoPopDelay = 10000;
            ttRegex.InitialDelay = 500;
            ttRegex.ReshowDelay = 100;
            ttRegex.ToolTipIcon = ToolTipIcon.Info;
            ttRegex.ToolTipTitle = "Find text using regular expressions";
            // 
            // timKeyPresses
            // 
            timKeyPresses.Tick += TimKeyPresses_Tick;
            // 
            // cmbVoices
            // 
            cmbVoices.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVoices.FormattingEnabled = true;
            cmbVoices.Location = new Point(620, 3);
            cmbVoices.Name = "cmbVoices";
            cmbVoices.Size = new Size(206, 28);
            cmbVoices.TabIndex = 8;
            // 
            // btnChangeVoiceName
            // 
            btnChangeVoiceName.FlatStyle = FlatStyle.System;
            btnChangeVoiceName.Location = new Point(827, 2);
            btnChangeVoiceName.Name = "btnChangeVoiceName";
            btnChangeVoiceName.Size = new Size(48, 30);
            btnChangeVoiceName.TabIndex = 10;
            btnChangeVoiceName.Text = "Ok";
            btnChangeVoiceName.ToolTipText = null;
            btnChangeVoiceName.UseVisualStyleBackColor = true;
            btnChangeVoiceName.Click += BtnChangeVoiceName_Click;
            // 
            // btnInsertVoicesJson
            // 
            btnInsertVoicesJson.Location = new Point(620, 70);
            btnInsertVoicesJson.Name = "btnInsertVoicesJson";
            btnInsertVoicesJson.Size = new Size(85, 28);
            btnInsertVoicesJson.TabIndex = 12;
            btnInsertVoicesJson.Text = "Insert VCS";
            btnInsertVoicesJson.ToolTipText = "Adds data about characters and voices at the top of an oppened text file";
            btnInsertVoicesJson.UseVisualStyleBackColor = true;
            btnInsertVoicesJson.Click += BtnInsertVoicesJson_Click;
            // 
            // dgvVoices
            // 
            dgvVoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvVoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVoices.EnableHeadersVisualStyles = false;
            dgvVoices.Location = new Point(3, 3);
            dgvVoices.Name = "dgvVoices";
            dgvVoices.RowHeadersWidth = 5;
            dgvVoices.Size = new Size(611, 129);
            dgvVoices.TabIndex = 13;
            dgvVoices.CellDoubleClick += DgvVoices_CellDoubleClick;
            // 
            // btnApplyVoice
            // 
            btnApplyVoice.Location = new Point(620, 104);
            btnApplyVoice.Name = "btnApplyVoice";
            btnApplyVoice.Size = new Size(85, 28);
            btnApplyVoice.TabIndex = 14;
            btnApplyVoice.Text = "Apply";
            btnApplyVoice.ToolTipText = "Applies selected voice from the table to selected input text";
            btnApplyVoice.UseVisualStyleBackColor = true;
            btnApplyVoice.Click += BtnApplyVoice_Click;
            // 
            // lblSearchResults
            // 
            lblSearchResults.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSearchResults.Location = new Point(845, 42);
            lblSearchResults.Margin = new Padding(0);
            lblSearchResults.Name = "lblSearchResults";
            lblSearchResults.Size = new Size(27, 25);
            lblSearchResults.TabIndex = 16;
            lblSearchResults.Click += Search_Click;
            // 
            // txtReplace
            // 
            txtReplace.Location = new Point(720, 102);
            txtReplace.Name = "txtReplace";
            txtReplace.PlaceholderText = "Replace";
            txtReplace.Size = new Size(124, 27);
            txtReplace.TabIndex = 18;
            // 
            // btnFindNext
            // 
            btnFindNext.FlatStyle = FlatStyle.System;
            btnFindNext.Font = new Font("Segoe UI", 12F);
            btnFindNext.Location = new Point(844, 69);
            btnFindNext.Name = "btnFindNext";
            btnFindNext.Size = new Size(29, 29);
            btnFindNext.TabIndex = 17;
            btnFindNext.Text = "➡";
            btnFindNext.ToolTipText = "Move to next";
            btnFindNext.UseVisualStyleBackColor = true;
            btnFindNext.Click += BtnFindNext_Click;
            // 
            // btnReplace
            // 
            btnReplace.FlatStyle = FlatStyle.System;
            btnReplace.Font = new Font("Segoe UI", 12F);
            btnReplace.Location = new Point(844, 101);
            btnReplace.Name = "btnReplace";
            btnReplace.Size = new Size(29, 29);
            btnReplace.TabIndex = 19;
            btnReplace.Text = "✏";
            btnReplace.ToolTipText = "Replace";
            btnReplace.UseVisualStyleBackColor = true;
            btnReplace.Click += BtnReplace_Click;
            // 
            // cmbFind
            // 
            cmbFind.FormattingEnabled = true;
            cmbFind.Location = new Point(720, 69);
            cmbFind.Name = "cmbFind";
            cmbFind.Size = new Size(124, 28);
            cmbFind.TabIndex = 16;
            cmbFind.SelectedIndexChanged += CmbFind_SelectedIndexChanged;
            cmbFind.TextChanged += CmbFind_TextChanged;
            cmbFind.KeyDown += CmbFind_KeyDown;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(numFontSize);
            pnlTop.Controls.Add(cmbFind);
            pnlTop.Controls.Add(label3);
            pnlTop.Controls.Add(dgvVoices);
            pnlTop.Controls.Add(btnPauseResume);
            pnlTop.Controls.Add(btnReplace);
            pnlTop.Controls.Add(numVolume);
            pnlTop.Controls.Add(cmbVoices);
            pnlTop.Controls.Add(label2);
            pnlTop.Controls.Add(btnFindNext);
            pnlTop.Controls.Add(numRate);
            pnlTop.Controls.Add(btnChangeVoiceName);
            pnlTop.Controls.Add(label1);
            pnlTop.Controls.Add(txtReplace);
            pnlTop.Controls.Add(btnStop);
            pnlTop.Controls.Add(btnInsertVoicesJson);
            pnlTop.Controls.Add(btnSpeak);
            pnlTop.Controls.Add(lblSearchResults);
            pnlTop.Controls.Add(btnApplyVoice);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlTop.Location = new Point(0, 24);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1236, 135);
            pnlTop.TabIndex = 3;
            // 
            // FrmMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1236, 595);
            Controls.Add(scMain);
            Controls.Add(pnlTop);
            Controls.Add(stripMenu);
            Controls.Add(stripStatus);
            KeyPreview = true;
            MainMenuStrip = stripMenu;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Story Reader";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            scMain.Panel1.ResumeLayout(false);
            scMain.Panel1.PerformLayout();
            scMain.Panel2.ResumeLayout(false);
            scMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)scMain).EndInit();
            scMain.ResumeLayout(false);
            pnlStoryTextHeader.ResumeLayout(false);
            pnlStoryTextHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numFontSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRate).EndInit();
            stripStatus.ResumeLayout(false);
            stripStatus.PerformLayout();
            stripMenu.ResumeLayout(false);
            stripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVoices).EndInit();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer scMain;
        private TextBox txtIn;
        private TextBox txtOut;
        private NumericUpDown numVolume;
        private Label label2;
        private NumericUpDown numRate;
        private Label label1;
        private Controls.UcButton btnStop;
        private Controls.UcButton btnSpeak;
        private OpenFileDialog ofd;
        private Controls.UcButton btnPauseResume;
        private StatusStrip stripStatus;
        private MenuStrip stripMenu;
        private ToolStripMenuItem tsmiFile;
        private ToolStripMenuItem tsmiFileOpen;
        private ToolStripMenuItem tsmiFileSave;
        private ToolStripStatusLabel lblLastStatus;
        private System.Windows.Forms.Timer timStatus;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem tsmiRemoveDuplicateLetters;
        private ToolStripMenuItem tsmiInsertOvertype;
        private ToolStripMenuItem tsmiAddSpaceAfterPunctuation;
        private ToolStripMenuItem tsmiFileBrowse;
        private NumericUpDown numFontSize;
        private ToolStripMenuItem tsmiEditUndo;
        private Panel pnlStoryTextHeader;
        private Label lblFileHeader;
        private ToolTip ttRegex;
        private System.Windows.Forms.Timer timKeyPresses;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem tsmiViewTheme;
        private ToolStripMenuItem tsmiLightMode;
        private ToolStripMenuItem tsmiDarkMode;
        private ComboBox cmbVoices;
        private Controls.UcButton btnChangeVoiceName;
        private Controls.UcButton btnInsertVoicesJson;
        private DataGridView dgvVoices;
        private Controls.UcButton btnApplyVoice;
        private Label lblSearchResults;
        private TextBox txtReplace;
        private Controls.UcButton btnFindNext;
        private Controls.UcButton btnReplace;
        private ComboBox cmbFind;
        private Panel pnlTop;
    }
}
