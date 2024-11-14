using System.Security.Cryptography;

namespace ApiKeyGenerator
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            using (var hmac = new HMACSHA256())
            {
               
                // Génère une clé unique aléatoire encodée en base64
                var apiKey= Convert.ToBase64String(hmac.Key);
                Console.WriteLine($"API Key générée : {apiKey}");
            }
           
        }
    }
}
