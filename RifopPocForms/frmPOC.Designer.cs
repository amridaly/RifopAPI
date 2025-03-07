namespace RifopPocForms
{
    partial class frmPOC
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
            lblTitle = new Label();
            toolStrip1 = new ToolStrip();
            statusStrip1 = new StatusStrip();
            splitContainer1 = new SplitContainer();
            btnSYSSearch = new Button();
            txtSYSSexe = new TextBox();
            txtSYSDateNaiss = new TextBox();
            txtSYSPrenom = new TextBox();
            txtSYSNom = new TextBox();
            txtSYSNIF = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            picONIPhoto = new PictureBox();
            txtONISexe = new TextBox();
            lblCorrespondance = new Label();
            label7 = new Label();
            txtONINinu = new TextBox();
            txtONIDateNaiss = new TextBox();
            groupBox1 = new GroupBox();
            btnONIPhoto = new Button();
            btnONIEmpreinte = new Button();
            txtONIPrenom = new TextBox();
            label12 = new Label();
            label8 = new Label();
            txtONINom = new TextBox();
            label11 = new Label();
            label9 = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picONIPhoto).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Tahoma", 16.2F, FontStyle.Bold);
            lblTitle.ForeColor = SystemColors.ActiveCaption;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1132, 86);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "POC. I";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Location = new Point(0, 86);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1132, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 657);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1132, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 111);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnSYSSearch);
            splitContainer1.Panel1.Controls.Add(txtSYSSexe);
            splitContainer1.Panel1.Controls.Add(txtSYSDateNaiss);
            splitContainer1.Panel1.Controls.Add(txtSYSPrenom);
            splitContainer1.Panel1.Controls.Add(txtSYSNom);
            splitContainer1.Panel1.Controls.Add(txtSYSNIF);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(picONIPhoto);
            splitContainer1.Panel2.Controls.Add(txtONISexe);
            splitContainer1.Panel2.Controls.Add(lblCorrespondance);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(txtONINinu);
            splitContainer1.Panel2.Controls.Add(txtONIDateNaiss);
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Panel2.Controls.Add(txtONIPrenom);
            splitContainer1.Panel2.Controls.Add(label12);
            splitContainer1.Panel2.Controls.Add(label8);
            splitContainer1.Panel2.Controls.Add(txtONINom);
            splitContainer1.Panel2.Controls.Add(label11);
            splitContainer1.Panel2.Controls.Add(label9);
            splitContainer1.Panel2.Controls.Add(label10);
            splitContainer1.Size = new Size(1132, 546);
            splitContainer1.SplitterDistance = 564;
            splitContainer1.TabIndex = 3;
            // 
            // btnSYSSearch
            // 
            btnSYSSearch.Image = Properties.Resources.srch_16;
            btnSYSSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSYSSearch.Location = new Point(353, 87);
            btnSYSSearch.Name = "btnSYSSearch";
            btnSYSSearch.Size = new Size(142, 33);
            btnSYSSearch.TabIndex = 0;
            btnSYSSearch.Text = "Chercher";
            btnSYSSearch.UseVisualStyleBackColor = true;
            btnSYSSearch.Click += btnSYSSearch_Click;
            // 
            // txtSYSSexe
            // 
            txtSYSSexe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSYSSexe.Location = new Point(118, 293);
            txtSYSSexe.Name = "txtSYSSexe";
            txtSYSSexe.ReadOnly = true;
            txtSYSSexe.Size = new Size(163, 27);
            txtSYSSexe.TabIndex = 3;
            // 
            // txtSYSDateNaiss
            // 
            txtSYSDateNaiss.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSYSDateNaiss.Location = new Point(161, 241);
            txtSYSDateNaiss.Name = "txtSYSDateNaiss";
            txtSYSDateNaiss.ReadOnly = true;
            txtSYSDateNaiss.Size = new Size(163, 27);
            txtSYSDateNaiss.TabIndex = 3;
            // 
            // txtSYSPrenom
            // 
            txtSYSPrenom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSYSPrenom.Location = new Point(118, 188);
            txtSYSPrenom.Name = "txtSYSPrenom";
            txtSYSPrenom.ReadOnly = true;
            txtSYSPrenom.Size = new Size(403, 27);
            txtSYSPrenom.TabIndex = 3;
            // 
            // txtSYSNom
            // 
            txtSYSNom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSYSNom.Location = new Point(118, 144);
            txtSYSNom.Name = "txtSYSNom";
            txtSYSNom.ReadOnly = true;
            txtSYSNom.Size = new Size(403, 27);
            txtSYSNom.TabIndex = 3;
            // 
            // txtSYSNIF
            // 
            txtSYSNIF.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSYSNIF.Location = new Point(117, 90);
            txtSYSNIF.MaxLength = 13;
            txtSYSNIF.Name = "txtSYSNIF";
            txtSYSNIF.Size = new Size(230, 27);
            txtSYSNIF.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 296);
            label6.Name = "label6";
            label6.Size = new Size(40, 20);
            label6.TabIndex = 1;
            label6.Text = "Sexe";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 244);
            label5.Name = "label5";
            label5.Size = new Size(111, 20);
            label5.TabIndex = 1;
            label5.Text = "Date Naissance";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 195);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 1;
            label4.Text = "Prénoms";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 147);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 1;
            label3.Text = "Nom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 97);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 1;
            label2.Text = "NIF";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(56, 35);
            label1.Name = "label1";
            label1.Size = new Size(182, 24);
            label1.TabIndex = 0;
            label1.Text = "Données SYSPAY";
            // 
            // picONIPhoto
            // 
            picONIPhoto.Location = new Point(353, 137);
            picONIPhoto.Name = "picONIPhoto";
            picONIPhoto.Size = new Size(146, 146);
            picONIPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            picONIPhoto.TabIndex = 4;
            picONIPhoto.TabStop = false;
            // 
            // txtONISexe
            // 
            txtONISexe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtONISexe.Location = new Point(411, 406);
            txtONISexe.Name = "txtONISexe";
            txtONISexe.ReadOnly = true;
            txtONISexe.Size = new Size(115, 27);
            txtONISexe.TabIndex = 3;
            // 
            // lblCorrespondance
            // 
            lblCorrespondance.AutoSize = true;
            lblCorrespondance.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            lblCorrespondance.ForeColor = Color.FromArgb(0, 192, 0);
            lblCorrespondance.Location = new Point(27, 475);
            lblCorrespondance.Name = "lblCorrespondance";
            lblCorrespondance.Size = new Size(243, 24);
            lblCorrespondance.TabIndex = 1;
            lblCorrespondance.Text = "Correspondance 100%";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label7.ForeColor = SystemColors.Highlight;
            label7.Location = new Point(24, 144);
            label7.Name = "label7";
            label7.Size = new Size(168, 24);
            label7.TabIndex = 1;
            label7.Text = "Données RIFOP";
            // 
            // txtONINinu
            // 
            txtONINinu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtONINinu.Location = new Point(123, 237);
            txtONINinu.Name = "txtONINinu";
            txtONINinu.ReadOnly = true;
            txtONINinu.Size = new Size(104, 27);
            txtONINinu.TabIndex = 3;
            // 
            // txtONIDateNaiss
            // 
            txtONIDateNaiss.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtONIDateNaiss.Location = new Point(157, 402);
            txtONIDateNaiss.Name = "txtONIDateNaiss";
            txtONIDateNaiss.ReadOnly = true;
            txtONIDateNaiss.Size = new Size(104, 27);
            txtONIDateNaiss.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnONIPhoto);
            groupBox1.Controls.Add(btnONIEmpreinte);
            groupBox1.Location = new Point(24, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(522, 92);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Authentification Par";
            // 
            // btnONIPhoto
            // 
            btnONIPhoto.Location = new Point(278, 39);
            btnONIPhoto.Name = "btnONIPhoto";
            btnONIPhoto.Size = new Size(184, 33);
            btnONIPhoto.TabIndex = 0;
            btnONIPhoto.Text = "Photo";
            btnONIPhoto.UseVisualStyleBackColor = true;
            btnONIPhoto.Click += btnONIPhoto_Click;
            // 
            // btnONIEmpreinte
            // 
            btnONIEmpreinte.Location = new Point(33, 39);
            btnONIEmpreinte.Name = "btnONIEmpreinte";
            btnONIEmpreinte.Size = new Size(184, 33);
            btnONIEmpreinte.TabIndex = 0;
            btnONIEmpreinte.Text = "Empreinte Digitale";
            btnONIEmpreinte.UseVisualStyleBackColor = true;
            // 
            // txtONIPrenom
            // 
            txtONIPrenom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtONIPrenom.Location = new Point(123, 344);
            txtONIPrenom.Name = "txtONIPrenom";
            txtONIPrenom.ReadOnly = true;
            txtONIPrenom.Size = new Size(403, 27);
            txtONIPrenom.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(353, 413);
            label12.Name = "label12";
            label12.Size = new Size(40, 20);
            label12.TabIndex = 1;
            label12.Text = "Sexe";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(27, 247);
            label8.Name = "label8";
            label8.Size = new Size(45, 20);
            label8.TabIndex = 1;
            label8.Text = "NINU";
            // 
            // txtONINom
            // 
            txtONINom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtONINom.Location = new Point(123, 292);
            txtONINom.Name = "txtONINom";
            txtONINom.ReadOnly = true;
            txtONINom.Size = new Size(403, 27);
            txtONINom.TabIndex = 3;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(27, 405);
            label11.Name = "label11";
            label11.Size = new Size(111, 20);
            label11.TabIndex = 1;
            label11.Text = "Date Naissance";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(27, 295);
            label9.Name = "label9";
            label9.Size = new Size(42, 20);
            label9.TabIndex = 1;
            label9.Text = "Nom";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(27, 351);
            label10.Name = "label10";
            label10.Size = new Size(66, 20);
            label10.TabIndex = 1;
            label10.Text = "Prénoms";
            // 
            // frmPOC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 679);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(lblTitle);
            Name = "frmPOC";
            Text = "POC I";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picONIPhoto).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private SplitContainer splitContainer1;
        private TextBox txtSYSNom;
        private TextBox txtSYSNIF;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtSYSSexe;
        private TextBox txtSYSDateNaiss;
        private TextBox txtSYSPrenom;
        private TextBox txtONISexe;
        private Label label7;
        private TextBox txtONIDateNaiss;
        private GroupBox groupBox1;
        private Button btnONIPhoto;
        private Button btnONIEmpreinte;
        private TextBox txtONIPrenom;
        private Label label12;
        private Label label8;
        private TextBox txtONINom;
        private Label label11;
        private Label label9;
        private Label label10;
        private PictureBox picONIPhoto;
        private Label lblCorrespondance;
        private TextBox txtONINinu;
        private Button btnSYSSearch;
    }
}
