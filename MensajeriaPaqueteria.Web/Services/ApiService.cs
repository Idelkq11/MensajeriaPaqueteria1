using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Web.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        // Constructor que recibe IHttpClientFactory
        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // Método para solicitudes GET
        public async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error: {response.StatusCode}, {response.ReasonPhrase}");

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Método para solicitudes POST
        public async Task<T?> PostAsync<T>(string endpoint, object data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            Console.WriteLine($"[PostAsync] Enviando JSON: {jsonData}");

            var response = await _httpClient.PostAsync(endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"[PostAsync] Respuesta API ({response.StatusCode}): {responseContent}");

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error: {response.StatusCode}, {response.ReasonPhrase}");

            if (string.IsNullOrWhiteSpace(responseContent) ||
                (!responseContent.TrimStart().StartsWith("{") && !responseContent.TrimStart().StartsWith("[")))
            {
                Console.WriteLine("[PostAsync] La respuesta no es JSON, devolviendo valor por defecto.");
                return default;
            }

            try
            {
                return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"[PostAsync] Error al deserializar JSON: {ex.Message}");
                Console.WriteLine($"[PostAsync] JSON recibido: {responseContent}");
                throw;
            }
        }

        // Método para solicitudes PUT
        public async Task<T?> PutAsync<T>(string endpoint, object data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            Console.WriteLine($"[PutAsync] Enviando JSON: {jsonData}");

            var response = await _httpClient.PutAsync(endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"[PutAsync] Respuesta API ({response.StatusCode}): {responseContent}");

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error: {response.StatusCode}, {response.ReasonPhrase}");

            if (string.IsNullOrWhiteSpace(responseContent) ||
                (!responseContent.TrimStart().StartsWith("{") && !responseContent.TrimStart().StartsWith("[")))
            {
                Console.WriteLine("[PutAsync] La respuesta no es JSON, devolviendo valor por defecto.");
                return default;
            }

            try
            {
                return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"[PutAsync] Error al deserializar JSON: {ex.Message}");
                Console.WriteLine($"[PutAsync] JSON recibido: {responseContent}");
                throw;
            }
        }

        // Método para solicitudes DELETE
        public async Task DeleteAsync(string endpoint)
        {
            var response = await _httpClient.DeleteAsync(endpoint);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }
    }
}
