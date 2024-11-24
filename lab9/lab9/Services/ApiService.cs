using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Lab9.Models;

namespace Lab9.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Метод для отримання списку об'єктів
        public async Task<List<T>> GetAllAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<T>>() ?? new List<T>();
            }
            throw new HttpRequestException($"Error fetching data: {response.ReasonPhrase}");
        }

        // Метод для отримання одного об'єкта за ID
        public async Task<T?> GetByIdAsync<T>(string endpoint, int id)
        {
            var response = await _httpClient.GetAsync($"{endpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            throw new HttpRequestException($"Error fetching data: {response.ReasonPhrase}");
        }

        // Метод для додавання нового об'єкта
        public async Task<T?> AddAsync<T>(string endpoint, T item)
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, item);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            throw new HttpRequestException($"Error adding data: {response.ReasonPhrase}");
        }

        // Метод для оновлення об'єкта
        public async Task UpdateAsync<T>(string endpoint, int id, T item)
        {
            var response = await _httpClient.PutAsJsonAsync($"{endpoint}/{id}", item);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error updating data: {response.ReasonPhrase}");
            }
        }

        // Метод для видалення об'єкта
        public async Task DeleteAsync(string endpoint, int id)
        {
            var response = await _httpClient.DeleteAsync($"{endpoint}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error deleting data: {response.ReasonPhrase}");
            }
        }
    }
}
