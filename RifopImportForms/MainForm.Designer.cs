namespace RifopImportForms
{
    partial class MainForm
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
            progressBar1 = new ProgressBar();
            btnStart = new Button();
            lblTimeRemaining = new Label();
            btnStop = new Button();
            lblProgress = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(104, 120);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(608, 29);
            progressBar1.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(107, 234);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lblTimeRemaining
            // 
            lblTimeRemaining.AutoSize = true;
            lblTimeRemaining.Location = new Point(107, 190);
            lblTimeRemaining.Name = "lblTimeRemaining";
            lblTimeRemaining.Size = new Size(18, 20);
            lblTimeRemaining.TabIndex = 2;
            lblTimeRemaining.Text = "...";
            // 
            // btnStop
            // 
            btnStop.Location = new Point(216, 234);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(94, 29);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(107, 152);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(18, 20);
            lblProgress.TabIndex = 2;
            lblProgress.Text = "...";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblProgress);
            Controls.Add(lblTimeRemaining);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(progressBar1);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Button btnStart;
        private Label lblTimeRemaining;
        private Button btnStop;
        private Label lblProgress;
    }
}
