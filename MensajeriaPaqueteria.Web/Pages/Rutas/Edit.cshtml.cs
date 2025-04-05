using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Application.Dtos;

namespace MensajeriaPaqueteria.Web.Pages.Rutas
{
    public class EditModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public RutaDto Ruta { get; set; } = new();

        public List<MensajeroDto> Mensajeros { get; set; } = new();

        public EditModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Ruta = await _apiService.GetAsync<RutaDto>($"Rutas/{id}") ?? new RutaDto();

            if (Ruta.RutaId == 0) // Verificar que la ruta existe
                return NotFound();

            Mensajeros = await _apiService.GetAsync<List<MensajeroDto>>("Mensajero") ?? new List<MensajeroDto>();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Ruta.RutaId == 0) // Verificar que RutaId es válido antes de actualizar
                return BadRequest("ID de ruta inválido");

            await _apiService.PutAsync<RutaDto>($"Rutas/{Ruta.RutaId}", Ruta);
            return RedirectToPage("Index");
        }
    }
}