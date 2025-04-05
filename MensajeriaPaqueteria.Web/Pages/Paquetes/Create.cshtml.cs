using MensajeriaPaqueteria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;

namespace MensajeriaPaqueteria.Web.Pages.Paquetes
{
    public class CreateModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public Paquete Paquete { get; set; }

        public CreateModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiService.PostAsync<Paquete>("Paquetes", Paquete);
            return RedirectToPage("Index");
        }
    }
}
