using Kaira.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Kaira.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetKombinOnerisi(string userPrompt)
        {
            if (string.IsNullOrEmpty(userPrompt))
            {
                return Json(new { success = false, message = "Lütfen bir durum veya kýyafet girin." });
            }

            // API Key'ini buraya (veya tercihen appsettings'e) koy
            string apiKey = "AIzaSyBNa2OwFSuwHG64Opf3HuMb8tFOWUNCByA";
            string apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash-lite:generateContent?key={apiKey}";

            var payload = new
            {
                contents = new[]
                {
            new
            {
                parts = new[]
                {
                    new { text = $"Sen uzman bir moda danýþmaný ve stilistsin. Kullanýcý sana gitmek istediði yeri veya elindeki bir parçayý söyleyecek. Sen de ona uygun, þýk ve detaylý bir kombin önerisi yapacaksýn. Kullanýcýnýn girdisi: {userPrompt}" }
                }
            }
        }
            };

            string jsonPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        using (JsonDocument doc = JsonDocument.Parse(responseString))
                        {
                            var root = doc.RootElement;
                            // Gemini yanýt yapýsýna göre path kontrolü
                            if (root.TryGetProperty("candidates", out var candidates) && candidates.GetArrayLength() > 0)
                            {
                                string geminiCevabi = candidates[0]
                                                   .GetProperty("content")
                                                   .GetProperty("parts")[0]
                                                   .GetProperty("text")
                                                   .GetString();

                                // BAÞARILI: JSON formatýnda veriyi döndürüyoruz
                                return Json(new { success = true, message = geminiCevabi });
                            }
                        }
                    }
                    return Json(new { success = false, message = "API'den cevap alýnamadý." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Hata: " + ex.Message });
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
