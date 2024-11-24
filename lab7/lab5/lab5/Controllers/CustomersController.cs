using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab5.Controllers
{
    public class CustomersController : Controller
    {
        private readonly HttpClient _httpClient;

        public CustomersController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Lab7API");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("customers");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = "Помилка отримання списку клієнтів.";
                return View(new List<dynamic>());
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            dynamic customers = JsonConvert.DeserializeObject<dynamic>(jsonData);
            return View(customers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"customers/{id}");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = "Помилка отримання деталей клієнта.";
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            dynamic customer = JsonConvert.DeserializeObject<dynamic>(jsonData);
            return View(customer);
        }

        public async Task<IActionResult> Search(string? firstName, string? lastName, string? email)
        {
            var queryParams = new List<string>();
            
            if (!string.IsNullOrEmpty(firstName))
                queryParams.Add($"firstName={firstName}");
            if (!string.IsNullOrEmpty(lastName))
                queryParams.Add($"lastName={lastName}");
            if (!string.IsNullOrEmpty(email))
                queryParams.Add($"email={email}");

            var queryString = string.Join("&", queryParams);
            var response = await _httpClient.GetAsync($"customers/search?{queryString}");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = "Помилка виконання пошуку.";
                return View(new List<dynamic>());
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            dynamic results = JsonConvert.DeserializeObject<dynamic>(jsonData);
            return View(results);
        }

    }
}
