using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Web.Pages.Envios
{
    public class CreateModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public EnvioDto Envio { get; set; } = new EnvioDto();

        public List<PaqueteDto> Paquetes { get; set; }
        public List<MensajeroDto> Mensajeros { get; set; }

        public CreateModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            // Cargar listas de datos antes de mostrar la vista
            Paquetes = await _apiService.GetAsync<List<PaqueteDto>>("Paquetes");
            Mensajeros = await _apiService.GetAsync<List<MensajeroDto>>("Mensajero");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiService.PostAsync<EnvioDto>("Envio", Envio);
            return RedirectToPage("Index");
        }
    }
}
