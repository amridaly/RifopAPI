using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json; // Pour ReadFromJsonAsync
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;
using System.Net.Http.Headers;
using System.DirectoryServices.Protocols;
using RifopLibrary;

namespace RifopImportForms
{


    public class CitizenApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly Serilog.ILogger _logger;
        string _apiUrl = Program.Configuration["ApiBaseUrl"];
        string _appKey = Program.Configuration["ApiKey"];

        public CitizenApiClient(Serilog.ILogger logger)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("x-api-key", _appKey);
            _httpClient.BaseAddress = new Uri(_apiUrl);

            _logger = logger;
        }

        public async Task<Personne> GetCitizenDataAsync(long nin)
        {

            string url = $"NifNinus/PersonByNinu/{nin}";
            int retryCount = 3;


            for (int i = 0; i < retryCount; i++)
            {

                var response = await _httpClient.GetAsync(url); // $"{_apiUrl}{url}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Personne>();
                }
                else
                {
                    _logger.Error($"Erreur API pour NIN {nin}: {response.StatusCode} - {response.ReasonPhrase}, Tentative {i + 1}/{retryCount}");
                    if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        throw new HttpRequestException($"Erreur API pour NIN {nin}: {response.StatusCode} - {response.ReasonPhrase}, Tentative {i + 1}/{retryCount}");
                    }
                }

            }

            _logger.Warning($"Échec après {retryCount} tentatives pour NIN {nin}");
            return null; // Retourne null en cas d'échec après les tentatives
        }
    }
}
