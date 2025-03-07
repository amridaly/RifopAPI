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
            progressBar1.Location = new Point(91, 90);
            progressBar1.Margin = new Padding(3, 2, 3, 2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(532, 22);
            progressBar1.TabIndex = 0;
            progressBar1.Value = 50;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(94, 176);
            btnStart.Margin = new Padding(3, 2, 3, 2);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(82, 22);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lblTimeRemaining
            // 
            lblTimeRemaining.AutoSize = true;
            lblTimeRemaining.Location = new Point(94, 142);
            lblTimeRemaining.Name = "lblTimeRemaining";
            lblTimeRemaining.Size = new Size(144, 15);
            lblTimeRemaining.TabIndex = 2;
            lblTimeRemaining.Text = "Temps restant : 19H:58mn";
            // 
            // btnStop
            // 
            btnStop.Location = new Point(189, 176);
            btnStop.Margin = new Padding(3, 2, 3, 2);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(82, 22);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(94, 114);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(200, 15);
            lblProgress.TabIndex = 2;
            lblProgress.Text = "Progression : 1500000/2500000 (50%)";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(lblProgress);
            Controls.Add(lblTimeRemaining);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(progressBar1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Enrichissement de la Base de Référence";
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
