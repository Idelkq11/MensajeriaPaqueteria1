using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Application.Dtos;

namespace MensajeriaPaqueteria.Web.Pages.Rutas
{
    public class CreateModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public RutaDto Ruta { get; set; } = new();

        public List<MensajeroDto> Mensajeros { get; set; } = new();

        public CreateModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            Mensajeros = await _apiService.GetAsync<List<MensajeroDto>>("Mensajero") ?? new List<MensajeroDto>();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _apiService.PostAsync<RutaDto>("Rutas", Ruta);
            return RedirectToPage("Index");
        }
    }
}

