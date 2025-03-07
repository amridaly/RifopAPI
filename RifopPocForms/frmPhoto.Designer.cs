namespace RifopPocForms
{
    partial class frmPhoto
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
            picPhoto = new PictureBox();
            btnCapture = new Button();
            buttonZoomIn = new Button();
            buttonZoomOut = new Button();
            hScrollBar1 = new HScrollBar();
            vScrollBar1 = new VScrollBar();
            btnValider = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            SuspendLayout();
            // 
            // picPhoto
            // 
            picPhoto.Location = new Point(31, 38);
            picPhoto.Name = "picPhoto";
            picPhoto.Size = new Size(270, 270);
            picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            picPhoto.TabIndex = 0;
            picPhoto.TabStop = false;
            // 
            // btnCapture
            // 
            btnCapture.Location = new Point(31, 320);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(137, 30);
            btnCapture.TabIndex = 1;
            btnCapture.Text = "Capturer";
            btnCapture.UseVisualStyleBackColor = true;
            btnCapture.Click += btnCapture_Click;
            // 
            // buttonZoomIn
            // 
            buttonZoomIn.Location = new Point(377, 35);
            buttonZoomIn.Name = "buttonZoomIn";
            buttonZoomIn.Size = new Size(35, 29);
            buttonZoomIn.TabIndex = 2;
            buttonZoomIn.Text = "-";
            buttonZoomIn.UseVisualStyleBackColor = true;
            buttonZoomIn.Visible = false;
            buttonZoomIn.Click += buttonZoomIn_Click;
            // 
            // buttonZoomOut
            // 
            buttonZoomOut.Location = new Point(377, 9);
            buttonZoomOut.Name = "buttonZoomOut";
            buttonZoomOut.Size = new Size(35, 29);
            buttonZoomOut.TabIndex = 2;
            buttonZoomOut.Text = "+";
            buttonZoomOut.UseVisualStyleBackColor = true;
            buttonZoomOut.Visible = false;
            buttonZoomOut.Click += buttonZoomOut_Click;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(12, 291);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(266, 26);
            hScrollBar1.TabIndex = 3;
            hScrollBar1.Visible = false;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(415, 9);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(26, 276);
            vScrollBar1.TabIndex = 4;
            vScrollBar1.Visible = false;
            vScrollBar1.Scroll += vScrollBar1_Scroll;
            // 
            // btnValider
            // 
            btnValider.Location = new Point(155, 365);
            btnValider.Name = "btnValider";
            btnValider.Size = new Size(137, 42);
            btnValider.TabIndex = 1;
            btnValider.Text = "Valider";
            btnValider.UseVisualStyleBackColor = true;
            btnValider.Click += btnValider_Click;
            // 
            // button1
            // 
            button1.CausesValidation = false;
            button1.DialogResult = DialogResult.Cancel;
            button1.Location = new Point(12, 365);
            button1.Name = "button1";
            button1.Size = new Size(137, 42);
            button1.TabIndex = 1;
            button1.Text = "Annuler";
            button1.UseVisualStyleBackColor = true;
            // 
            // frmPhoto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 448);
            Controls.Add(vScrollBar1);
            Controls.Add(hScrollBar1);
            Controls.Add(buttonZoomOut);
            Controls.Add(buttonZoomIn);
            Controls.Add(button1);
            Controls.Add(btnValider);
            Controls.Add(btnCapture);
            Controls.Add(picPhoto);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPhoto";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Authentification Faciale";
            FormClosing += frmPhoto_FormClosing;
            Load += frmPhoto_Load;
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picPhoto;
        private Button btnCapture;
        private Button buttonZoomIn;
        private Button buttonZoomOut;
        private HScrollBar hScrollBar1;
        private VScrollBar vScrollBar1;
        private Button btnValider;
        private Button button1;
    }
}