using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json; // Pour ReadFromJsonAsync
using System.Threading.Tasks;

using System.Net.Http.Headers;

using RifopLibrary;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Net.Mime;

namespace RifopPocForms
{


    public class RifopApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly Serilog.ILogger _logger;
        string _apiUrl = Program.Configuration["ApiBaseUrl"];
        string _appKey = Program.Configuration["ApiKey"];

        public RifopApiClient(Serilog.ILogger logger)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("x-api-key", _appKey);
            _httpClient.BaseAddress = new Uri(_apiUrl);

            _logger = logger;
        }

        public async Task<Personne> FaceIdentification(Bitmap photo)
        {

            string url = $"ONIBiometrics/FaceIdentification";
            int retryCount = 3;


            for (int i = 0; i < retryCount; i++)
            {
                using var content = new MultipartFormDataContent();
                using var fileStream = new System.IO.MemoryStream();
                photo.Save(fileStream, ImageFormat.Png);
                fileStream.Position = 0;
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                // Ajoutez le fichier au contenu de la requête
                content.Add(fileContent, "photo", "photo");


                // Envoyer la requête à l'API ONI

                var response = await _httpClient.PostAsync(url, content); 

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Personne>();
                }
                else
                {
                    _logger.Error($"Erreur API pour FaceIdentification: {response.StatusCode} - {response.ReasonPhrase}, Tentative {i + 1}/{retryCount}");
                    if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        throw new HttpRequestException($"Erreur API pour FaceIdentification: {response.StatusCode} - {response.ReasonPhrase}, Tentative {i + 1}/{retryCount}");
                    }
                }

            }

            _logger.Warning($"Échec après {retryCount} tentatives pour FaceIdentification");
            return null;
        }

        internal async Task<Image> GetPhoto(long ninu)
        {
            string url = $"NifNinus/GetImageByNinu/{ninu}";
            int retryCount = 3;


            for (int i = 0; i < retryCount; i++)
            {

                var response = await _httpClient.GetAsync(url); // $"{_apiUrl}{url}");

                if (response.IsSuccessStatusCode)
                {

                    var photo = await response.Content.ReadFromJsonAsync<Photo>();

                    try
                    {
                        // Convertir la chaîne base64 en tableau d'octets
                        byte[] imageBytes = Convert.FromBase64String(photo.Data);

                        // Créer un MemoryStream à partir du tableau d'octets
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            // Créer une image à partir du MemoryStream
                            Image image = Image.FromStream(ms);

                            return image;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erreur lors de la conversion de l'image : " + ex.Message);
                    }
                }
                else
                {
                    _logger.Error($"Erreur API GetImageByNinu pour NNU {ninu}: {response.StatusCode} - {response.ReasonPhrase}, Tentative {i + 1}/{retryCount}");
                    if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        throw new HttpRequestException($"Erreur API GetImageByNinu pour NNU {ninu}: {response.StatusCode} - {response.ReasonPhrase}, Tentative {i + 1}/{retryCount}");
                    }
                }

            }

            _logger.Warning($"Échec après {retryCount} tentatives pour GetImageByNinu {ninu}");
            return null;
        }
    }
}
