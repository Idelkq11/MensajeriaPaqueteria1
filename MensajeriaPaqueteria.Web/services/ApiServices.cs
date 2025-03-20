using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Web.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // Método para solicitudes GET (para obtener una lista de paquetes o datos en general)
        public async Task<T?> GetAsync<T>(string endpoint)
        {
            var requestUri = new Uri(_httpClient.BaseAddress!, endpoint);
            var response = await _httpClient.GetAsync(requestUri);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error: {response.StatusCode}, {response.ReasonPhrase}");

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Método para solicitudes POST (para crear un nuevo paquete o datos)
        public async Task<T?> PostAsync<T>(string endpoint, object data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error: {response.StatusCode}, {response.ReasonPhrase}");

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Método para solicitudes PUT (para actualizar un paquete o datos existentes)
        public async Task<T?> PutAsync<T>(string endpoint, object data)
        {
            var requestUri = new Uri(_httpClient.BaseAddress!, endpoint);
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(requestUri, content);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error: {response.StatusCode}, {response.ReasonPhrase}");

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Método para solicitudes DELETE (para eliminar un paquete o datos)
        public async Task DeleteAsync(string endpoint)
        {
            var requestUri = new Uri(_httpClient.BaseAddress!, endpoint);
            var response = await _httpClient.DeleteAsync(requestUri);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }
    }
}

