using System;
using System.Windows.Forms;
using RifopLibrary;

namespace RifopPocForms
{
    public partial class frmSelection : Form
    {
        public Employe SelectedPerson { get; private set; }

        public frmSelection(Employe[] personnes)
        {
            InitializeComponent();
            personneBindingSource.DataSource = personnes;
            
        }


        private void listBoxPersons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }
            SelectedPerson = listBoxPersons.Rows[e.RowIndex].DataBoundItem as Employe;
            if(SelectedPerson != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }


        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            listBoxPersons = new DataGridView();
            personneBindingSource = new BindingSource(components);
            label1 = new Label();
            clnCode = new DataGridViewTextBoxColumn();
            clnNINU = new DataGridViewTextBoxColumn();
            clnNom = new DataGridViewTextBoxColumn();
            clnPrenom = new DataGridViewTextBoxColumn();
            clnDateNaiss = new DataGridViewTextBoxColumn();
            lIEUNAISSANCEDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sEXEDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pOSTEDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sTATUTDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)listBoxPersons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personneBindingSource).BeginInit();
            SuspendLayout();
            // 
            // listBoxPersons
            // 
            listBoxPersons.AllowUserToAddRows = false;
            listBoxPersons.AllowUserToDeleteRows = false;
            listBoxPersons.AllowUserToOrderColumns = true;
            listBoxPersons.AutoGenerateColumns = false;
            listBoxPersons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listBoxPersons.Columns.AddRange(new DataGridViewColumn[] { clnCode, clnNINU, clnNom, clnPrenom, clnDateNaiss, lIEUNAISSANCEDataGridViewTextBoxColumn, sEXEDataGridViewTextBoxColumn, pOSTEDataGridViewTextBoxColumn, sTATUTDataGridViewTextBoxColumn });
            listBoxPersons.DataSource = personneBindingSource;
            listBoxPersons.Dock = DockStyle.Fill;
            listBoxPersons.Location = new Point(0, 52);
            listBoxPersons.MultiSelect = false;
            listBoxPersons.Name = "listBoxPersons";
            listBoxPersons.ReadOnly = true;
            listBoxPersons.RowHeadersWidth = 51;
            listBoxPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            listBoxPersons.Size = new Size(1192, 293);
            listBoxPersons.TabIndex = 0;
            listBoxPersons.CellDoubleClick += listBoxPersons_CellDoubleClick;
            // 
            // personneBindingSource
            // 
            personneBindingSource.DataSource = typeof(Employe);
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1192, 52);
            label1.TabIndex = 1;
            label1.Text = "Veuillez sélectionner une ligne (Double clique)";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clnCode
            // 
            clnCode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            clnCode.DataPropertyName = "EMPLOYE_ID";
            clnCode.Frozen = true;
            clnCode.HeaderText = "Code";
            clnCode.MinimumWidth = 6;
            clnCode.Name = "clnCode";
            clnCode.ReadOnly = true;
            clnCode.Width = 73;
            // 
            // clnNINU
            // 
            clnNINU.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            clnNINU.DataPropertyName = "TAXPAYER_NIF";
            clnNINU.HeaderText = "NIF";
            clnNINU.MinimumWidth = 6;
            clnNINU.Name = "clnNINU";
            clnNINU.ReadOnly = true;
            clnNINU.Width = 60;
            // 
            // clnNom
            // 
            clnNom.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            clnNom.DataPropertyName = "NOM";
            clnNom.HeaderText = "Nom";
            clnNom.MinimumWidth = 6;
            clnNom.Name = "clnNom";
            clnNom.ReadOnly = true;
            clnNom.Width = 71;
            // 
            // clnPrenom
            // 
            clnPrenom.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            clnPrenom.DataPropertyName = "PRENOM";
            clnPrenom.HeaderText = "Prénoms";
            clnPrenom.MinimumWidth = 6;
            clnPrenom.Name = "clnPrenom";
            clnPrenom.ReadOnly = true;
            clnPrenom.Width = 95;
            // 
            // clnDateNaiss
            // 
            clnDateNaiss.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            clnDateNaiss.DataPropertyName = "DATE_NAISSANCE";
            dataGridViewCellStyle1.Format = "dd/MM/YYYY";
            clnDateNaiss.DefaultCellStyle = dataGridViewCellStyle1;
            clnDateNaiss.HeaderText = "Date Naissance";
            clnDateNaiss.MinimumWidth = 6;
            clnDateNaiss.Name = "clnDateNaiss";
            clnDateNaiss.ReadOnly = true;
            clnDateNaiss.Width = 140;
            // 
            // lIEUNAISSANCEDataGridViewTextBoxColumn
            // 
            lIEUNAISSANCEDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lIEUNAISSANCEDataGridViewTextBoxColumn.DataPropertyName = "LIEU_NAISSANCE";
            lIEUNAISSANCEDataGridViewTextBoxColumn.HeaderText = "Lieu de Naissance";
            lIEUNAISSANCEDataGridViewTextBoxColumn.MinimumWidth = 6;
            lIEUNAISSANCEDataGridViewTextBoxColumn.Name = "lIEUNAISSANCEDataGridViewTextBoxColumn";
            lIEUNAISSANCEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sEXEDataGridViewTextBoxColumn
            // 
            sEXEDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            sEXEDataGridViewTextBoxColumn.DataPropertyName = "SEXE";
            sEXEDataGridViewTextBoxColumn.HeaderText = "Sexe";
            sEXEDataGridViewTextBoxColumn.MinimumWidth = 6;
            sEXEDataGridViewTextBoxColumn.Name = "sEXEDataGridViewTextBoxColumn";
            sEXEDataGridViewTextBoxColumn.ReadOnly = true;
            sEXEDataGridViewTextBoxColumn.Width = 69;
            // 
            // pOSTEDataGridViewTextBoxColumn
            // 
            pOSTEDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            pOSTEDataGridViewTextBoxColumn.DataPropertyName = "POSTE";
            pOSTEDataGridViewTextBoxColumn.HeaderText = "Poste";
            pOSTEDataGridViewTextBoxColumn.MinimumWidth = 6;
            pOSTEDataGridViewTextBoxColumn.Name = "pOSTEDataGridViewTextBoxColumn";
            pOSTEDataGridViewTextBoxColumn.ReadOnly = true;
            pOSTEDataGridViewTextBoxColumn.Width = 73;
            // 
            // sTATUTDataGridViewTextBoxColumn
            // 
            sTATUTDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            sTATUTDataGridViewTextBoxColumn.DataPropertyName = "STATUT";
            sTATUTDataGridViewTextBoxColumn.HeaderText = "STATUT";
            sTATUTDataGridViewTextBoxColumn.MinimumWidth = 6;
            sTATUTDataGridViewTextBoxColumn.Name = "sTATUTDataGridViewTextBoxColumn";
            sTATUTDataGridViewTextBoxColumn.ReadOnly = true;
            sTATUTDataGridViewTextBoxColumn.Width = 88;
            // 
            // frmSelection
            // 
            ClientSize = new Size(1192, 345);
            Controls.Add(listBoxPersons);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "frmSelection";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)listBoxPersons).EndInit();
            ((System.ComponentModel.ISupportInitialize)personneBindingSource).EndInit();
            ResumeLayout(false);

        }
        private DataGridView listBoxPersons;
        private BindingSource personneBindingSource;
        private System.ComponentModel.IContainer components;
        private DataGridViewTextBoxColumn clnCode;
        private DataGridViewTextBoxColumn clnNINU;
        private DataGridViewTextBoxColumn clnNom;
        private DataGridViewTextBoxColumn clnPrenom;
        private DataGridViewTextBoxColumn clnDateNaiss;
        private DataGridViewTextBoxColumn lIEUNAISSANCEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sEXEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pOSTEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sTATUTDataGridViewTextBoxColumn;
        private Label label1;


    }
}
