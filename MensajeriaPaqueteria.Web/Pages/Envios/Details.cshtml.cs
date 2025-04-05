using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Web.Services;

namespace MensajeriaPaqueteria.Web.Pages.Envios
{
    public class DetailsModel : PageModel
    {
        private readonly ApiService _apiService;

        public EnvioDto Envio { get; set; } = new EnvioDto();

        // ? Propiedad Ubicaci�n (tra�da desde el env�o)
        public string Ubicacion { get; set; } = string.Empty;

        public DetailsModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Obtener los datos del env�o desde la API
            Envio = await _apiService.GetAsync<EnvioDto>($"Envio/{id}");

            if (Envio == null)
            {
                return NotFound();
            }

            // ? Asignar la ubicaci�n si existe
            Ubicacion = Envio.UbicacionActual ?? "18.4861,-69.9312"; // Santo Domingo, RD por defecto

            return Page();
        }
    }
}

