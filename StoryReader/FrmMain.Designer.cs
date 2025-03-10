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
            splitContainer1 = new SplitContainer();
            txtIn = new TextBox();
            pnlLeftTop = new Panel();
            dgvVoices = new DataGridView();
            btnCopyVoicesJson = new Button();
            btnSaveFile = new Button();
            btnOpenFile = new Button();
            btnCopyVoiceName = new Button();
            cmbVoices = new ComboBox();
            txtOut = new TextBox();
            pnlRightTop = new Panel();
            btnTest = new Button();
            numVolume = new NumericUpDown();
            label2 = new Label();
            numRate = new NumericUpDown();
            label1 = new Label();
            btnStop = new Button();
            btnSpeak = new Button();
            ofd = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pnlLeftTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVoices).BeginInit();
            pnlRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRate).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Font = new Font("Segoe UI", 11.25F);
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtIn);
            splitContainer1.Panel1.Controls.Add(pnlLeftTop);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtOut);
            splitContainer1.Panel2.Controls.Add(pnlRightTop);
            splitContainer1.Size = new Size(1236, 595);
            splitContainer1.SplitterDistance = 616;
            splitContainer1.TabIndex = 0;
            // 
            // txtIn
            // 
            txtIn.Dock = DockStyle.Fill;
            txtIn.Location = new Point(0, 128);
            txtIn.Multiline = true;
            txtIn.Name = "txtIn";
            txtIn.ScrollBars = ScrollBars.Vertical;
            txtIn.Size = new Size(616, 467);
            txtIn.TabIndex = 1;
            txtIn.Text = "<voice name=\"cousin\">\"Looks like it's your turn\"</voice> my cousin said to me with a laugh.";
            // 
            // pnlLeftTop
            // 
            pnlLeftTop.Controls.Add(dgvVoices);
            pnlLeftTop.Controls.Add(btnCopyVoicesJson);
            pnlLeftTop.Controls.Add(btnSaveFile);
            pnlLeftTop.Controls.Add(btnOpenFile);
            pnlLeftTop.Controls.Add(btnCopyVoiceName);
            pnlLeftTop.Controls.Add(cmbVoices);
            pnlLeftTop.Dock = DockStyle.Top;
            pnlLeftTop.Location = new Point(0, 0);
            pnlLeftTop.Name = "pnlLeftTop";
            pnlLeftTop.Size = new Size(616, 128);
            pnlLeftTop.TabIndex = 0;
            // 
            // dgvVoices
            // 
            dgvVoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVoices.Location = new Point(264, 7);
            dgvVoices.Name = "dgvVoices";
            dgvVoices.Size = new Size(349, 115);
            dgvVoices.TabIndex = 13;
            // 
            // btnCopyVoicesJson
            // 
            btnCopyVoicesJson.Location = new Point(183, 10);
            btnCopyVoicesJson.Name = "btnCopyVoicesJson";
            btnCopyVoicesJson.Size = new Size(75, 28);
            btnCopyVoicesJson.TabIndex = 12;
            btnCopyVoicesJson.Text = "Copy vcs";
            btnCopyVoicesJson.UseVisualStyleBackColor = true;
            btnCopyVoicesJson.Click += BtnCopyVoicesJson_Click;
            // 
            // btnSaveFile
            // 
            btnSaveFile.Location = new Point(12, 49);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(75, 28);
            btnSaveFile.TabIndex = 11;
            btnSaveFile.Text = "Save";
            btnSaveFile.UseVisualStyleBackColor = true;
            btnSaveFile.Click += BtnSaveFile_Click;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(12, 15);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(75, 28);
            btnOpenFile.TabIndex = 9;
            btnOpenFile.Text = "Open...";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += BtnOpenFile_Click;
            // 
            // btnCopyVoiceName
            // 
            btnCopyVoiceName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCopyVoiceName.FlatStyle = FlatStyle.System;
            btnCopyVoiceName.Location = new Point(210, 97);
            btnCopyVoiceName.Name = "btnCopyVoiceName";
            btnCopyVoiceName.Size = new Size(48, 28);
            btnCopyVoiceName.TabIndex = 10;
            btnCopyVoiceName.Text = "Copy";
            btnCopyVoiceName.UseVisualStyleBackColor = true;
            btnCopyVoiceName.Click += BtnCopyVoiceName_Click;
            // 
            // cmbVoices
            // 
            cmbVoices.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cmbVoices.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVoices.FormattingEnabled = true;
            cmbVoices.Location = new Point(3, 97);
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
            txtOut.Size = new Size(616, 467);
            txtOut.TabIndex = 2;
            // 
            // pnlRightTop
            // 
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
            // btnTest
            // 
            btnTest.Location = new Point(326, 45);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(75, 28);
            btnTest.TabIndex = 11;
            btnTest.Text = "Test";
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
            // numRate
            // 
            numRate.Location = new Point(52, 12);
            numRate.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numRate.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            numRate.Name = "numRate";
            numRate.Size = new Size(54, 27);
            numRate.TabIndex = 10;
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
            // btnStop
            // 
            btnStop.Location = new Point(177, 44);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 28);
            btnStop.TabIndex = 6;
            btnStop.Text = "Don't";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += BtnStop_Click;
            // 
            // btnSpeak
            // 
            btnSpeak.Location = new Point(177, 11);
            btnSpeak.Name = "btnSpeak";
            btnSpeak.Size = new Size(75, 28);
            btnSpeak.TabIndex = 5;
            btnSpeak.Text = "Speak";
            btnSpeak.UseVisualStyleBackColor = true;
            btnSpeak.Click += BtnSpeak_Click;
            // 
            // ofd
            // 
            ofd.AddToRecent = false;
            ofd.Filter = "Test files|*.txt|Html files|*.htm*|All files|*.*";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 595);
            Controls.Add(splitContainer1);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += FrmMain_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            pnlLeftTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVoices).EndInit();
            pnlRightTop.ResumeLayout(false);
            pnlRightTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRate).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox txtIn;
        private Panel pnlLeftTop;
        private Button btnCopyVoicesJson;
        private Button btnSaveFile;
        private Button btnOpenFile;
        private Button btnCopyVoiceName;
        private ComboBox cmbVoices;
        private TextBox txtOut;
        private Panel pnlRightTop;
        private Button btnTest;
        private NumericUpDown numVolume;
        private Label label2;
        private NumericUpDown numRate;
        private Label label1;
        private Button btnStop;
        private Button btnSpeak;
        private OpenFileDialog ofd;
        private DataGridView dgvVoices;
    }
}
