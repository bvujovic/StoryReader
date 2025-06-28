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
            rtbOut = new RichTextBox();
            ctxOut = new ContextMenuStrip(components);
            tsmiOut_FindSelection = new ToolStripMenuItem();
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
            tsmiFileClose = new ToolStripMenuItem();
            tsmiFileSave = new ToolStripMenuItem();
            tsmiFileBrowse = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            tsmiEditUndo = new ToolStripMenuItem();
            tsmiRemoveDuplicateLetters = new ToolStripMenuItem();
            tsmiInsertOvertype = new ToolStripMenuItem();
            tsmiAddSpaceAfterPunctuation = new ToolStripMenuItem();
            tsmiEditRemoveLineBreaks = new ToolStripMenuItem();
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
            ctxFind = new ContextMenuStrip(components);
            tsmiFind_RemoveSearch = new ToolStripMenuItem();
            btnReplace = new StoryReader.Controls.UcButton();
            cmbFind = new ComboBox();
            pnlTop = new Panel();
            btnMp3 = new StoryReader.Controls.UcButton();
            btnForward = new Button();
            btnBackward = new Button();
            tsmiVoices = new ToolStripMenuItem();
            tsmiVoicesAzureVoices = new ToolStripMenuItem();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)scMain).BeginInit();
            scMain.Panel1.SuspendLayout();
            scMain.Panel2.SuspendLayout();
            scMain.SuspendLayout();
            ctxOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFontSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRate).BeginInit();
            stripStatus.SuspendLayout();
            stripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVoices).BeginInit();
            ctxFind.SuspendLayout();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(1043, 40);
            label2.Name = "label2";
            label2.Size = new Size(30, 20);
            label2.TabIndex = 7;
            label2.Text = "Vol";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(1043, 7);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 8;
            label1.Text = "Rate";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(1045, 73);
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
            // 
            // scMain.Panel2
            // 
            scMain.Panel2.Controls.Add(rtbOut);
            scMain.Size = new Size(1236, 414);
            scMain.SplitterDistance = 616;
            scMain.TabIndex = 0;
            // 
            // txtIn
            // 
            txtIn.Dock = DockStyle.Fill;
            txtIn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIn.Location = new Point(0, 0);
            txtIn.MaxLength = 100000;
            txtIn.Multiline = true;
            txtIn.Name = "txtIn";
            txtIn.ScrollBars = ScrollBars.Vertical;
            txtIn.Size = new Size(616, 414);
            txtIn.TabIndex = 1;
            txtIn.TextChanged += TxtIn_TextChanged;
            txtIn.KeyDown += TxtIn_KeyDown;
            txtIn.KeyPress += TxtIn_KeyPress;
            // 
            // rtbOut
            // 
            rtbOut.ContextMenuStrip = ctxOut;
            rtbOut.Dock = DockStyle.Fill;
            rtbOut.Font = new Font("Segoe UI", 12F);
            rtbOut.Location = new Point(0, 0);
            rtbOut.Name = "rtbOut";
            rtbOut.Size = new Size(616, 414);
            rtbOut.TabIndex = 4;
            rtbOut.Text = "";
            // 
            // ctxOut
            // 
            ctxOut.Items.AddRange(new ToolStripItem[] { tsmiOut_FindSelection });
            ctxOut.Name = "ctxOut";
            ctxOut.Size = new Size(149, 26);
            ctxOut.Opening += CtxOut_Opening;
            // 
            // tsmiOut_FindSelection
            // 
            tsmiOut_FindSelection.Name = "tsmiOut_FindSelection";
            tsmiOut_FindSelection.Size = new Size(148, 22);
            tsmiOut_FindSelection.Text = "Find Selection";
            tsmiOut_FindSelection.Click += TsmiOut_FindSelection_Click;
            // 
            // numFontSize
            // 
            numFontSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numFontSize.Location = new Point(1089, 71);
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
            numVolume.Location = new Point(1088, 38);
            numVolume.Name = "numVolume";
            numVolume.Size = new Size(54, 27);
            numVolume.TabIndex = 9;
            numVolume.Value = new decimal(new int[] { 65, 0, 0, 0 });
            numVolume.ValueChanged += NumVolume_ValueChanged;
            // 
            // numRate
            // 
            numRate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numRate.Location = new Point(1088, 5);
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
            stripMenu.Items.AddRange(new ToolStripItem[] { tsmiFile, editToolStripMenuItem, viewToolStripMenuItem, tsmiVoices });
            stripMenu.Location = new Point(0, 0);
            stripMenu.Name = "stripMenu";
            stripMenu.Size = new Size(1236, 24);
            stripMenu.TabIndex = 2;
            stripMenu.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            tsmiFile.DropDownItems.AddRange(new ToolStripItem[] { tsmiFileOpen, tsmiFileClose, tsmiFileSave, tsmiFileBrowse });
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
            // tsmiFileClose
            // 
            tsmiFileClose.Name = "tsmiFileClose";
            tsmiFileClose.Size = new Size(155, 22);
            tsmiFileClose.Text = "Close";
            tsmiFileClose.Click += TsmiFileClose_Click;
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
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiEditUndo, tsmiRemoveDuplicateLetters, tsmiInsertOvertype, tsmiAddSpaceAfterPunctuation, tsmiEditRemoveLineBreaks });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // tsmiEditUndo
            // 
            tsmiEditUndo.Name = "tsmiEditUndo";
            tsmiEditUndo.ShortcutKeys = Keys.Control | Keys.Z;
            tsmiEditUndo.Size = new Size(265, 22);
            tsmiEditUndo.Text = "Undo";
            tsmiEditUndo.Click += TsmiEditUndo_Click;
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
            // tsmiEditRemoveLineBreaks
            // 
            tsmiEditRemoveLineBreaks.Name = "tsmiEditRemoveLineBreaks";
            tsmiEditRemoveLineBreaks.Size = new Size(265, 22);
            tsmiEditRemoveLineBreaks.Text = "Remove line breaks mid-sentence";
            tsmiEditRemoveLineBreaks.Click += TsmiEditRemoveLineBreaks_Click;
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
            tsmiViewTheme.Size = new Size(180, 22);
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
            cmbVoices.Location = new Point(771, 3);
            cmbVoices.Name = "cmbVoices";
            cmbVoices.Size = new Size(206, 28);
            cmbVoices.TabIndex = 8;
            // 
            // btnChangeVoiceName
            // 
            btnChangeVoiceName.FlatStyle = FlatStyle.System;
            btnChangeVoiceName.Location = new Point(978, 2);
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
            btnInsertVoicesJson.Location = new Point(771, 70);
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
            dgvVoices.RowHeadersWidth = 40;
            dgvVoices.Size = new Size(762, 129);
            dgvVoices.TabIndex = 13;
            dgvVoices.CellDoubleClick += DgvVoices_CellDoubleClick;
            dgvVoices.CellValidated += DgvVoices_CellValidated;
            dgvVoices.CellValidating += DgvVoices_CellValidating;
            // 
            // btnApplyVoice
            // 
            btnApplyVoice.Location = new Point(771, 104);
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
            lblSearchResults.Location = new Point(996, 42);
            lblSearchResults.Margin = new Padding(0);
            lblSearchResults.Name = "lblSearchResults";
            lblSearchResults.Size = new Size(27, 25);
            lblSearchResults.TabIndex = 16;
            lblSearchResults.Click += Search_Click;
            // 
            // txtReplace
            // 
            txtReplace.Location = new Point(871, 102);
            txtReplace.Name = "txtReplace";
            txtReplace.PlaceholderText = "Replace";
            txtReplace.Size = new Size(124, 27);
            txtReplace.TabIndex = 18;
            // 
            // btnFindNext
            // 
            btnFindNext.ContextMenuStrip = ctxFind;
            btnFindNext.FlatStyle = FlatStyle.System;
            btnFindNext.Font = new Font("Segoe UI", 12F);
            btnFindNext.Location = new Point(995, 69);
            btnFindNext.Name = "btnFindNext";
            btnFindNext.Size = new Size(29, 29);
            btnFindNext.TabIndex = 17;
            btnFindNext.Text = "➡";
            btnFindNext.ToolTipText = "Move to next";
            btnFindNext.UseVisualStyleBackColor = true;
            btnFindNext.Click += BtnFindNext_Click;
            // 
            // ctxFind
            // 
            ctxFind.Items.AddRange(new ToolStripItem[] { tsmiFind_RemoveSearch });
            ctxFind.Name = "ctxOut";
            ctxFind.Size = new Size(155, 26);
            // 
            // tsmiFind_RemoveSearch
            // 
            tsmiFind_RemoveSearch.Name = "tsmiFind_RemoveSearch";
            tsmiFind_RemoveSearch.Size = new Size(154, 22);
            tsmiFind_RemoveSearch.Text = "Remove search";
            tsmiFind_RemoveSearch.Click += TsmiFind_RemoveSearch_Click;
            // 
            // btnReplace
            // 
            btnReplace.FlatStyle = FlatStyle.System;
            btnReplace.Font = new Font("Segoe UI", 12F);
            btnReplace.Location = new Point(995, 101);
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
            cmbFind.ContextMenuStrip = ctxFind;
            cmbFind.FormattingEnabled = true;
            cmbFind.Location = new Point(871, 69);
            cmbFind.Name = "cmbFind";
            cmbFind.Size = new Size(124, 28);
            cmbFind.TabIndex = 16;
            cmbFind.SelectedIndexChanged += CmbFind_SelectedIndexChanged;
            cmbFind.TextChanged += CmbFind_TextChanged;
            cmbFind.KeyDown += CmbFind_KeyDown;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(btnMp3);
            pnlTop.Controls.Add(btnForward);
            pnlTop.Controls.Add(btnBackward);
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
            // btnMp3
            // 
            btnMp3.Location = new Point(771, 36);
            btnMp3.Name = "btnMp3";
            btnMp3.Size = new Size(85, 28);
            btnMp3.TabIndex = 22;
            btnMp3.Text = "mp3";
            btnMp3.ToolTipText = "Adds data about characters and voices at the top of an oppened text file";
            btnMp3.UseVisualStyleBackColor = true;
            btnMp3.Click += BtnMp3_Click;
            // 
            // btnForward
            // 
            btnForward.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnForward.FlatStyle = FlatStyle.System;
            btnForward.Font = new Font("Segoe UI", 12F);
            btnForward.Location = new Point(1188, 104);
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(36, 29);
            btnForward.TabIndex = 21;
            btnForward.Text = "⏩";
            btnForward.UseVisualStyleBackColor = true;
            btnForward.Click += BtnForward_Click;
            // 
            // btnBackward
            // 
            btnBackward.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBackward.FlatStyle = FlatStyle.System;
            btnBackward.Font = new Font("Segoe UI", 12F);
            btnBackward.Location = new Point(1149, 104);
            btnBackward.Margin = new Padding(0);
            btnBackward.Name = "btnBackward";
            btnBackward.Size = new Size(36, 29);
            btnBackward.TabIndex = 20;
            btnBackward.Text = "⏪";
            btnBackward.UseVisualStyleBackColor = true;
            btnBackward.Click += BtnBackward_Click;
            // 
            // tsmiVoices
            // 
            tsmiVoices.DropDownItems.AddRange(new ToolStripItem[] { tsmiVoicesAzureVoices });
            tsmiVoices.Name = "tsmiVoices";
            tsmiVoices.Size = new Size(52, 20);
            tsmiVoices.Text = "Voices";
            // 
            // tsmiVoicesAzureVoices
            // 
            tsmiVoicesAzureVoices.Name = "tsmiVoicesAzureVoices";
            tsmiVoicesAzureVoices.Size = new Size(180, 22);
            tsmiVoicesAzureVoices.Text = "Azure Voices...";
            tsmiVoicesAzureVoices.Click += TsmiVoicesAzureVoices_Click;
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
            ((System.ComponentModel.ISupportInitialize)scMain).EndInit();
            scMain.ResumeLayout(false);
            ctxOut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numFontSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRate).EndInit();
            stripStatus.ResumeLayout(false);
            stripStatus.PerformLayout();
            stripMenu.ResumeLayout(false);
            stripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVoices).EndInit();
            ctxFind.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer scMain;
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
        private Button btnBackward;
        private RichTextBox rtbOut;
        private ContextMenuStrip ctxOut;
        private ToolStripMenuItem tsmiOut_FindSelection;
        private Button btnForward;
        private ToolStripMenuItem tsmiFileClose;
        private ToolStripMenuItem tsmiEditRemoveLineBreaks;
        private TextBox txtIn;
        private ContextMenuStrip ctxFind;
        private ToolStripMenuItem tsmiFind_RemoveSearch;
        private Controls.UcButton btnMp3;
        private ToolStripMenuItem tsmiVoices;
        private ToolStripMenuItem tsmiVoicesAzureVoices;
    }
}
