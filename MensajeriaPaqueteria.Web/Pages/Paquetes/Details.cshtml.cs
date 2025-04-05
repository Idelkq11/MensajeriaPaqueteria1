using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Domain.Entities;

namespace MensajeriaPaqueteria.Web.Pages.Paquetes
{
    public class DetailsModel : PageModel
    {
        private readonly ApiService _apiService;

        public Paquete Paquete { get; set; }

        public DetailsModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Paquete = await _apiService.GetAsync<Paquete>($"Paquetes/{id}");
            if (Paquete == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
