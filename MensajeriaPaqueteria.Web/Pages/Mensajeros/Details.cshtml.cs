using MensajeriaPaqueteria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;

namespace MensajeriaPaqueteria.Web.Pages.Mensajeros
{
    public class DetailsModel : PageModel
    {
        private readonly ApiService _apiService;

        public Mensajero Mensajero { get; set; }

        public DetailsModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
           
            Mensajero = await _apiService.GetAsync<Mensajero>($"Mensajero/{id}");

            if (Mensajero == null)
            {
               
                return NotFound();
            }

            return Page();
        }
    }
}
