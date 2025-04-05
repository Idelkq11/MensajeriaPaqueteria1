using MensajeriaPaqueteria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;

namespace MensajeriaPaqueteria.Web.Pages.Mensajeros
{
    public class CreateModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public Mensajero Mensajero { get; set; }

        public CreateModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            await _apiService.PostAsync<Mensajero>("Mensajero", Mensajero);

            return RedirectToPage("Index");
        }
    }
}
