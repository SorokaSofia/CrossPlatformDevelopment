using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab5.Controllers
{
    public class ModelsController : Controller
    {
        private readonly HttpClient _httpClient;

        public ModelsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Lab7API");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("models");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = "Помилка отримання списку моделей.";
                return View(new List<dynamic>());
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            dynamic models = JsonConvert.DeserializeObject<dynamic>(jsonData);
            return View(models);
        }

        public async Task<IActionResult> Details(string id)
        {
            var response = await _httpClient.GetAsync($"models/{id}");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = "Помилка отримання деталей моделі.";
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            dynamic model = JsonConvert.DeserializeObject<dynamic>(jsonData);
            return View(model);
        }
    }
}
