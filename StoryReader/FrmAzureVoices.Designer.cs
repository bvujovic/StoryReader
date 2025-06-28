namespace StoryReader
{
    partial class FrmAzureVoices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtVoices = new TextBox();
            btnOk = new Button();
            pnlBottom = new Panel();
            btnListOfAllAzureVoices = new Button();
            scMain = new SplitContainer();
            txtTest = new TextBox();
            pnlLeftTop = new Panel();
            btnPlay = new Button();
            pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scMain).BeginInit();
            scMain.Panel1.SuspendLayout();
            scMain.Panel2.SuspendLayout();
            scMain.SuspendLayout();
            pnlLeftTop.SuspendLayout();
            SuspendLayout();
            // 
            // txtVoices
            // 
            txtVoices.AcceptsReturn = true;
            txtVoices.Dock = DockStyle.Fill;
            txtVoices.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtVoices.Location = new Point(0, 0);
            txtVoices.Multiline = true;
            txtVoices.Name = "txtVoices";
            txtVoices.ScrollBars = ScrollBars.Vertical;
            txtVoices.Size = new Size(370, 626);
            txtVoices.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(1027, 10);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // pnlBottom
            // 
            pnlBottom.Controls.Add(btnListOfAllAzureVoices);
            pnlBottom.Controls.Add(btnOk);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 626);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(1114, 44);
            pnlBottom.TabIndex = 2;
            // 
            // btnListOfAllAzureVoices
            // 
            btnListOfAllAzureVoices.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnListOfAllAzureVoices.Location = new Point(12, 10);
            btnListOfAllAzureVoices.Name = "btnListOfAllAzureVoices";
            btnListOfAllAzureVoices.Size = new Size(137, 23);
            btnListOfAllAzureVoices.TabIndex = 2;
            btnListOfAllAzureVoices.Text = "Go to All Azure Voices";
            btnListOfAllAzureVoices.UseVisualStyleBackColor = true;
            btnListOfAllAzureVoices.Click += BtnListOfAllAzureVoices_Click;
            // 
            // scMain
            // 
            scMain.Dock = DockStyle.Fill;
            scMain.FixedPanel = FixedPanel.Panel1;
            scMain.Location = new Point(0, 0);
            scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            scMain.Panel1.Controls.Add(txtVoices);
            // 
            // scMain.Panel2
            // 
            scMain.Panel2.Controls.Add(txtTest);
            scMain.Panel2.Controls.Add(pnlLeftTop);
            scMain.Size = new Size(1114, 626);
            scMain.SplitterDistance = 370;
            scMain.TabIndex = 3;
            // 
            // txtTest
            // 
            txtTest.AcceptsReturn = true;
            txtTest.Dock = DockStyle.Fill;
            txtTest.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTest.Location = new Point(0, 46);
            txtTest.Multiline = true;
            txtTest.Name = "txtTest";
            txtTest.ScrollBars = ScrollBars.Vertical;
            txtTest.Size = new Size(740, 580);
            txtTest.TabIndex = 1;
            // 
            // pnlLeftTop
            // 
            pnlLeftTop.Controls.Add(btnPlay);
            pnlLeftTop.Dock = DockStyle.Top;
            pnlLeftTop.Location = new Point(0, 0);
            pnlLeftTop.Name = "pnlLeftTop";
            pnlLeftTop.Size = new Size(740, 46);
            pnlLeftTop.TabIndex = 0;
            // 
            // btnPlay
            // 
            btnPlay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPlay.Location = new Point(12, 12);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 23);
            btnPlay.TabIndex = 3;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += BtnPlay_Click;
            // 
            // FrmAzureVoices
            // 
            AcceptButton = btnOk;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1114, 670);
            Controls.Add(scMain);
            Controls.Add(pnlBottom);
            Name = "FrmAzureVoices";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Azure Voices";
            FormClosing += FrmAzureVoices_FormClosing;
            pnlBottom.ResumeLayout(false);
            scMain.Panel1.ResumeLayout(false);
            scMain.Panel1.PerformLayout();
            scMain.Panel2.ResumeLayout(false);
            scMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)scMain).EndInit();
            scMain.ResumeLayout(false);
            pnlLeftTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtVoices;
        private Button btnOk;
        private Panel pnlBottom;
        private Button btnListOfAllAzureVoices;
        private SplitContainer scMain;
        private TextBox txtTest;
        private Panel pnlLeftTop;
        private Button btnPlay;
    }
}