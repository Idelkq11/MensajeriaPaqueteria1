using MensajeriaPaqueteria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;

namespace MensajeriaPaqueteria.Web.Pages.Mensajeros
{
    public class EditModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public Mensajero Mensajero { get; set; }

        public EditModel(ApiService apiService)
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
            if (!ModelState.IsValid)
            {
                
                return Page();
            }

          
            await _apiService.PutAsync<Mensajero>($"Mensajero/{Mensajero.MensajeroId}", Mensajero);

            
            return RedirectToPage("Index");
        }
    }
}
