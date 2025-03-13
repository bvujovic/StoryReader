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
            scMain = new SplitContainer();
            txtIn = new TextBox();
            pnlLeftTop = new Panel();
            btnReplace = new StoryReader.Controls.UcButton();
            btnNextReplace = new StoryReader.Controls.UcButton();
            txtReplace = new TextBox();
            lblSearchResults = new Label();
            txtSearch = new TextBox();
            btnApplyVoice = new StoryReader.Controls.UcButton();
            dgvVoices = new DataGridView();
            btnInsertVoicesJson = new StoryReader.Controls.UcButton();
            btnChangeVoiceName = new StoryReader.Controls.UcButton();
            cmbVoices = new ComboBox();
            txtOut = new TextBox();
            pnlRightTop = new Panel();
            btnPauseResume = new StoryReader.Controls.UcButton();
            btnTest = new StoryReader.Controls.UcButton();
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
            editToolStripMenuItem = new ToolStripMenuItem();
            timStatus = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)scMain).BeginInit();
            scMain.Panel1.SuspendLayout();
            scMain.Panel2.SuspendLayout();
            scMain.SuspendLayout();
            pnlLeftTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVoices).BeginInit();
            pnlRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRate).BeginInit();
            stripStatus.SuspendLayout();
            stripMenu.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 47);
            label2.Name = "label2";
            label2.Size = new Size(30, 20);
            label2.TabIndex = 7;
            label2.Text = "Vol";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 14);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 8;
            label1.Text = "Rate";
            // 
            // scMain
            // 
            scMain.Dock = DockStyle.Fill;
            scMain.Font = new Font("Segoe UI", 11.25F);
            scMain.Location = new Point(0, 24);
            scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            scMain.Panel1.Controls.Add(txtIn);
            scMain.Panel1.Controls.Add(pnlLeftTop);
            // 
            // scMain.Panel2
            // 
            scMain.Panel2.Controls.Add(txtOut);
            scMain.Panel2.Controls.Add(pnlRightTop);
            scMain.Size = new Size(1236, 549);
            scMain.SplitterDistance = 616;
            scMain.TabIndex = 0;
            // 
            // txtIn
            // 
            txtIn.Dock = DockStyle.Fill;
            txtIn.Location = new Point(0, 128);
            txtIn.Multiline = true;
            txtIn.Name = "txtIn";
            txtIn.ScrollBars = ScrollBars.Vertical;
            txtIn.Size = new Size(616, 421);
            txtIn.TabIndex = 1;
            txtIn.Text = "<voice name=\"cousin\">\"Looks like it's your turn to do it\"</voice> my cousin said to me with a smile";
            // 
            // pnlLeftTop
            // 
            pnlLeftTop.Controls.Add(btnReplace);
            pnlLeftTop.Controls.Add(btnNextReplace);
            pnlLeftTop.Controls.Add(txtReplace);
            pnlLeftTop.Controls.Add(lblSearchResults);
            pnlLeftTop.Controls.Add(txtSearch);
            pnlLeftTop.Controls.Add(btnApplyVoice);
            pnlLeftTop.Controls.Add(dgvVoices);
            pnlLeftTop.Controls.Add(btnInsertVoicesJson);
            pnlLeftTop.Controls.Add(btnChangeVoiceName);
            pnlLeftTop.Controls.Add(cmbVoices);
            pnlLeftTop.Dock = DockStyle.Top;
            pnlLeftTop.Location = new Point(0, 0);
            pnlLeftTop.Name = "pnlLeftTop";
            pnlLeftTop.Size = new Size(616, 128);
            pnlLeftTop.TabIndex = 0;
            pnlLeftTop.Click += PnlLeftTop_Click;
            // 
            // btnReplace
            // 
            btnReplace.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReplace.FlatStyle = FlatStyle.System;
            btnReplace.Font = new Font("Segoe UI", 12F);
            btnReplace.Location = new Point(555, 94);
            btnReplace.Name = "btnReplace";
            btnReplace.Size = new Size(28, 28);
            btnReplace.TabIndex = 19;
            btnReplace.Text = "✏";
            btnReplace.ToolTipText = "Replace";
            btnReplace.UseVisualStyleBackColor = true;
            btnReplace.Click += BtnReplace_Click;
            // 
            // btnNextReplace
            // 
            btnNextReplace.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNextReplace.FlatStyle = FlatStyle.System;
            btnNextReplace.Font = new Font("Segoe UI", 12F);
            btnNextReplace.Location = new Point(583, 94);
            btnNextReplace.Name = "btnNextReplace";
            btnNextReplace.Size = new Size(28, 28);
            btnNextReplace.TabIndex = 18;
            btnNextReplace.Text = "➡";
            btnNextReplace.ToolTipText = "Move to next";
            btnNextReplace.UseVisualStyleBackColor = true;
            // 
            // txtReplace
            // 
            txtReplace.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtReplace.Location = new Point(458, 95);
            txtReplace.Name = "txtReplace";
            txtReplace.PlaceholderText = "Replace";
            txtReplace.Size = new Size(96, 27);
            txtReplace.TabIndex = 17;
            // 
            // lblSearchResults
            // 
            lblSearchResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblSearchResults.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSearchResults.Location = new Point(583, 64);
            lblSearchResults.Margin = new Padding(0);
            lblSearchResults.Name = "lblSearchResults";
            lblSearchResults.Size = new Size(27, 25);
            lblSearchResults.TabIndex = 16;
            lblSearchResults.Click += Search_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtSearch.Location = new Point(458, 63);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Find";
            txtSearch.Size = new Size(124, 27);
            txtSearch.TabIndex = 15;
            txtSearch.Click += Search_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // btnApplyVoice
            // 
            btnApplyVoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApplyVoice.Location = new Point(358, 97);
            btnApplyVoice.Name = "btnApplyVoice";
            btnApplyVoice.Size = new Size(85, 28);
            btnApplyVoice.TabIndex = 14;
            btnApplyVoice.Text = "Apply";
            btnApplyVoice.ToolTipText = "Applies selected voice from the table to selected input text";
            btnApplyVoice.UseVisualStyleBackColor = true;
            btnApplyVoice.Click += BtnApplyVoice_Click;
            // 
            // dgvVoices
            // 
            dgvVoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVoices.Location = new Point(3, 3);
            dgvVoices.Name = "dgvVoices";
            dgvVoices.RowHeadersWidth = 5;
            dgvVoices.Size = new Size(349, 122);
            dgvVoices.TabIndex = 13;
            // 
            // btnInsertVoicesJson
            // 
            btnInsertVoicesJson.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnInsertVoicesJson.Location = new Point(358, 63);
            btnInsertVoicesJson.Name = "btnInsertVoicesJson";
            btnInsertVoicesJson.Size = new Size(85, 28);
            btnInsertVoicesJson.TabIndex = 12;
            btnInsertVoicesJson.Text = "Insert VCS";
            btnInsertVoicesJson.ToolTipText = "Adds data about characters and voices at the top of an oppened text file";
            btnInsertVoicesJson.UseVisualStyleBackColor = true;
            btnInsertVoicesJson.Click += BtnInsertVoicesJson_Click;
            // 
            // btnChangeVoiceName
            // 
            btnChangeVoiceName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangeVoiceName.FlatStyle = FlatStyle.System;
            btnChangeVoiceName.Location = new Point(565, 2);
            btnChangeVoiceName.Name = "btnChangeVoiceName";
            btnChangeVoiceName.Size = new Size(48, 30);
            btnChangeVoiceName.TabIndex = 10;
            btnChangeVoiceName.Text = "Ok";
            btnChangeVoiceName.ToolTipText = null;
            btnChangeVoiceName.UseVisualStyleBackColor = true;
            btnChangeVoiceName.Click += BtnChangeVoiceName_Click;
            // 
            // cmbVoices
            // 
            cmbVoices.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbVoices.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVoices.FormattingEnabled = true;
            cmbVoices.Location = new Point(358, 3);
            cmbVoices.Name = "cmbVoices";
            cmbVoices.Size = new Size(206, 28);
            cmbVoices.TabIndex = 8;
            // 
            // txtOut
            // 
            txtOut.Dock = DockStyle.Fill;
            txtOut.Location = new Point(0, 128);
            txtOut.Multiline = true;
            txtOut.Name = "txtOut";
            txtOut.ScrollBars = ScrollBars.Vertical;
            txtOut.Size = new Size(616, 421);
            txtOut.TabIndex = 2;
            // 
            // pnlRightTop
            // 
            pnlRightTop.Controls.Add(btnPauseResume);
            pnlRightTop.Controls.Add(btnTest);
            pnlRightTop.Controls.Add(numVolume);
            pnlRightTop.Controls.Add(label2);
            pnlRightTop.Controls.Add(numRate);
            pnlRightTop.Controls.Add(label1);
            pnlRightTop.Controls.Add(btnStop);
            pnlRightTop.Controls.Add(btnSpeak);
            pnlRightTop.Dock = DockStyle.Top;
            pnlRightTop.Location = new Point(0, 0);
            pnlRightTop.Name = "pnlRightTop";
            pnlRightTop.Size = new Size(616, 128);
            pnlRightTop.TabIndex = 0;
            // 
            // btnPauseResume
            // 
            btnPauseResume.Location = new Point(177, 78);
            btnPauseResume.Name = "btnPauseResume";
            btnPauseResume.Size = new Size(75, 28);
            btnPauseResume.TabIndex = 12;
            btnPauseResume.Text = "Pause";
            btnPauseResume.ToolTipText = "Play/Pause current speech";
            btnPauseResume.UseVisualStyleBackColor = true;
            btnPauseResume.Click += BtnPauseResume_Click;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(398, 14);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(75, 28);
            btnTest.TabIndex = 11;
            btnTest.Text = "Test";
            btnTest.ToolTipText = null;
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += BtnTest_Click;
            // 
            // numVolume
            // 
            numVolume.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numVolume.Location = new Point(52, 45);
            numVolume.Name = "numVolume";
            numVolume.Size = new Size(54, 27);
            numVolume.TabIndex = 9;
            numVolume.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numVolume.ValueChanged += NumVolume_ValueChanged;
            // 
            // numRate
            // 
            numRate.Location = new Point(52, 12);
            numRate.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numRate.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            numRate.Name = "numRate";
            numRate.Size = new Size(54, 27);
            numRate.TabIndex = 10;
            numRate.ValueChanged += NumRate_ValueChanged;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.LightCoral;
            btnStop.Location = new Point(177, 44);
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
            btnSpeak.BackColor = Color.LightGreen;
            btnSpeak.Location = new Point(177, 11);
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
            stripMenu.Items.AddRange(new ToolStripItem[] { tsmiFile, editToolStripMenuItem });
            stripMenu.Location = new Point(0, 0);
            stripMenu.Name = "stripMenu";
            stripMenu.Size = new Size(1236, 24);
            stripMenu.TabIndex = 2;
            stripMenu.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            tsmiFile.DropDownItems.AddRange(new ToolStripItem[] { tsmiFileOpen, tsmiFileSave });
            tsmiFile.Name = "tsmiFile";
            tsmiFile.Size = new Size(37, 20);
            tsmiFile.Text = "File";
            // 
            // tsmiFileOpen
            // 
            tsmiFileOpen.Name = "tsmiFileOpen";
            tsmiFileOpen.Size = new Size(103, 22);
            tsmiFileOpen.Text = "Open";
            tsmiFileOpen.Click += TsmiFileOpen_Click;
            // 
            // tsmiFileSave
            // 
            tsmiFileSave.Name = "tsmiFileSave";
            tsmiFileSave.Size = new Size(103, 22);
            tsmiFileSave.Text = "Save";
            tsmiFileSave.Click += TsmiFileSave_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // timStatus
            // 
            timStatus.Interval = 1000;
            timStatus.Tick += TimStatus_Tick;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 595);
            Controls.Add(scMain);
            Controls.Add(stripMenu);
            Controls.Add(stripStatus);
            MainMenuStrip = stripMenu;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Story Reader";
            Load += FrmMain_Load;
            scMain.Panel1.ResumeLayout(false);
            scMain.Panel1.PerformLayout();
            scMain.Panel2.ResumeLayout(false);
            scMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)scMain).EndInit();
            scMain.ResumeLayout(false);
            pnlLeftTop.ResumeLayout(false);
            pnlLeftTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVoices).EndInit();
            pnlRightTop.ResumeLayout(false);
            pnlRightTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRate).EndInit();
            stripStatus.ResumeLayout(false);
            stripStatus.PerformLayout();
            stripMenu.ResumeLayout(false);
            stripMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer scMain;
        private TextBox txtIn;
        private Panel pnlLeftTop;
        private Controls.UcButton btnInsertVoicesJson;
        private Controls.UcButton btnChangeVoiceName;
        private ComboBox cmbVoices;
        private TextBox txtOut;
        private Panel pnlRightTop;
        private Controls.UcButton btnTest;
        private NumericUpDown numVolume;
        private Label label2;
        private NumericUpDown numRate;
        private Label label1;
        private Controls.UcButton btnStop;
        private Controls.UcButton btnSpeak;
        private OpenFileDialog ofd;
        private DataGridView dgvVoices;
        private Controls.UcButton btnApplyVoice;
        private Controls.UcButton btnPauseResume;
        private StatusStrip stripStatus;
        private MenuStrip stripMenu;
        private ToolStripMenuItem tsmiFile;
        private ToolStripMenuItem tsmiFileOpen;
        private ToolStripMenuItem tsmiFileSave;
        private ToolStripStatusLabel lblLastStatus;
        private System.Windows.Forms.Timer timStatus;
        private ToolStripMenuItem editToolStripMenuItem;
        private TextBox txtSearch;
        private Label lblSearchResults;
        private TextBox txtReplace;
        private Controls.UcButton btnNextReplace;
        private Controls.UcButton btnReplace;
    }
}
