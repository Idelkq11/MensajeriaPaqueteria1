using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Application.Dtos;

namespace MensajeriaPaqueteria.Web.Pages.Rutas
{
    public class DeleteModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public RutaDto Ruta { get; set; } = new();

        public DeleteModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Ruta = await _apiService.GetAsync<RutaDto>($"Rutas/{id}") ?? new();

            if (Ruta == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Ruta.RutaId == 0)
                return NotFound();

            await _apiService.DeleteAsync($"Rutas/{Ruta.RutaId}");
            return RedirectToPage("Index");
        }
    }
}
