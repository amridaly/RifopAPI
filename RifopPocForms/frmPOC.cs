using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using RifopLibrary;

namespace RifopPocForms
{
    public partial class frmPOC : Form
    {
        private readonly SysPayApiClient _apiSysPayClient;
        private readonly RifopApiClient _apiRifopClient;
        private readonly Serilog.ILogger _logger;

        private Employe _currentPersonne;
        private Personne _currentPersonneRifop;


        public frmPOC()
        {
            InitializeComponent();

            _logger = Serilog.Log.Logger;

            _apiSysPayClient = new SysPayApiClient(_logger);
            _apiRifopClient = new RifopApiClient(_logger);
        }

        private async void btnSYSSearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ClearPerson();


            var nif = txtSYSNIF.Text.Trim();
            if (string.IsNullOrWhiteSpace(nif))
            {
                MessageBox.Show("Veuillez saisir un NIF valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var data = await _apiSysPayClient.GetEmployeDataAsync(nif);
                if (data.Length == 0)
                {
                    _logger.Error($"Données manquantes pour le NIF {nif}");
                    Cursor = Cursors.Default;
                    MessageBox.Show("NIF Introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (data.Length > 1)
                {

                    _logger.Error($"Données multiples pour le NIF {nif}");
                    //Afficher une fenêtre de dialogue pour sélectionner la personne à afficher

                    var frmSelection = new frmSelection(data);
                    Cursor = Cursors.Default;
                    if (frmSelection.ShowDialog() == DialogResult.OK)
                    {

                        AfficherSYS(frmSelection.SelectedPerson);
                    }
                    return;
                }
                var personne = data[0];
                AfficherSYS(personne);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la récupération des données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error($"Erreur lors de la récupération des données pour le NIF {nif}: {ex.Message}");
            }
        }

        private void ClearPerson()
        {
            _currentPersonne = null;
            txtSYSPrenom.Clear();
            txtSYSNom.Clear();
            txtSYSDateNaiss.Clear();
            txtSYSSexe.Clear();
        }

        private void AfficherSYS(Employe personne)
        {
            // Implémentation de la méthode pour afficher les informations de la personne
            _currentPersonne = personne;
            txtSYSPrenom.Text = personne.PRENOM;
            txtSYSNom.Text = personne.NOM;
            txtSYSDateNaiss.Text = personne.DATE_NAISSANCE?.ToString("dd/MM/yyyy");
            txtSYSSexe.Text = personne.SEXE;

        }
        private async Task AfficherRifop(Personne personne)
        {
            Cursor = Cursors.WaitCursor;

            ClearRifopPerson();

            txtONINinu.Text = personne.NINU.ToString();
            txtONINom.Text = personne.LastName;
            txtONIPrenom.Text = personne.FirstName;
            txtONIDateNaiss.Text = personne.BirthDate?.ToString("dd/MM/yyyy");
            txtONISexe.Text = personne.Gender;

            await GetPhotoByNinu(personne.NINU);
            Cursor = Cursors.Default;
        }
        private void ClearRifopPerson()
        {

            txtONINinu.Clear();
            txtONINom.Clear();
            txtONIPrenom.Clear();
            txtONIDateNaiss.Clear();
            txtONISexe.Clear();
            picONIPhoto.Image = null;
            lblCorrespondance.Text = string.Empty;
        }
        private async Task GetPhotoByNinu(long ninu)
        {
            try
            {
                picONIPhoto.Image = await _apiRifopClient.GetPhoto(ninu);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }

        }

        private void btnONIPhoto_Click(object sender, EventArgs e)
        {
            if (_currentPersonne == null)
            {
                MessageBox.Show("Vous devez chercher le fonctionnaire dans la base de données SYSPAY avant de faire l'authentification!");
                return;
            }
            var frmPhoto = new frmPhoto();
            if (frmPhoto.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;

                picONIPhoto.Image = frmPhoto.CapturedImage;


                AuthentificationFacile(frmPhoto.CapturedImage);

                Cursor = Cursors.Default;

            }

        }

        private async void AuthentificationFacile(Bitmap capturedImage)
        {
            try
            {

                var data = await _apiRifopClient.FaceIdentification(capturedImage);
                if (data == null)
                {
                    _logger.Error($"Authentification échouée!");
                    Cursor = Cursors.Default;
                    MessageBox.Show("Authentification échouée!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _currentPersonneRifop = data;
                await AfficherRifop(_currentPersonneRifop);
                Correspondance();

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Une erreur s'est produite lors de l Authentification.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error($"Erreur lors de l Authentification: {ex.Message}");
            }
        }

        private void Correspondance()
        {
            Correspectance = false;

            lblCorrespondance.Text = "";
            if (!_currentPersonne.NOM.Equals(_currentPersonneRifop.LastName))
                lblCorrespondance.Text = "Les noms ne correspondent pas";

            if (!_currentPersonne.PRENOM.Equals(_currentPersonneRifop.FirstName))
                lblCorrespondance.Text = "Les prénoms ne correspondent pas";

            if (_currentPersonne.DATE_NAISSANCE.HasValue && _currentPersonneRifop.BirthDate.HasValue
                && !_currentPersonne.DATE_NAISSANCE.Equals(_currentPersonneRifop.BirthDate))
                lblCorrespondance.Text = "Les dates de naissance ne correspondent pas";

            Correspectance = true;

        }

        private bool _correspondence = false;

        private bool Correspectance
        {
            get { return _correspondence; }
            set
            {
                _correspondence |= value;
                lblCorrespondance.ForeColor = _correspondence ? Color.Green : Color.Red;
            }
        }
    }
}
