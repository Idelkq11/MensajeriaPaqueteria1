using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Application.Dtos;

namespace MensajeriaPaqueteria.Web.Pages.Rutas
{
    public class DetailsModel : PageModel
    {
        private readonly ApiService _apiService;

        public RutaDto Ruta { get; set; } = new();

        public DetailsModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Ruta = await _apiService.GetAsync<RutaDto>($"Rutas/{id}");

            if (Ruta == null)
                return NotFound();

            return Page();
        }
    }
}
