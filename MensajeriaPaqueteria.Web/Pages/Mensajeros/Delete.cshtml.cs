using MensajeriaPaqueteria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;

namespace MensajeriaPaqueteria.Web.Pages.Mensajeros
{
    public class DeleteModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public Mensajero Mensajero { get; set; }

        public DeleteModel(ApiService apiService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (Mensajero == null)
            {
                return NotFound();
            }

            
            await _apiService.DeleteAsync($"Mensajero/{Mensajero.MensajeroId}");

            return RedirectToPage("Index");
        }
    }
}
