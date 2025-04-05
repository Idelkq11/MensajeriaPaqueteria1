using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Domain.Entities;

namespace MensajeriaPaqueteria.Web.Pages.Paquetes
{
    public class DeleteModel : PageModel
    {
        private readonly ApiService _apiService;

        public Paquete Paquete { get; set; }

        public DeleteModel(ApiService apiService)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _apiService.DeleteAsync($"Paquetes/{id}");
            return RedirectToPage("Index");
        }
    }
}
