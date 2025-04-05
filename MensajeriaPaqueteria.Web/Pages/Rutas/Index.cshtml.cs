using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Application.Dtos;

namespace MensajeriaPaqueteria.Web.Pages.Rutas
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public List<RutaDto> Rutas { get; set; } = new();

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            Rutas = await _apiService.GetAsync<List<RutaDto>>("Rutas") ?? new();
        }
    }
}
