using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab5.Controllers
{
    public class MechanicsController : Controller
    {
        private readonly HttpClient _httpClient;

        public MechanicsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Lab7API");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("mechanics");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = "Помилка отримання списку механіків.";
                return View(new List<dynamic>());
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            dynamic mechanics = JsonConvert.DeserializeObject<dynamic>(jsonData);
            return View(mechanics);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"mechanics/{id}");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = "Помилка отримання деталей механіка.";
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            dynamic mechanic = JsonConvert.DeserializeObject<dynamic>(jsonData);
            return View(mechanic);
        }
    }
}
