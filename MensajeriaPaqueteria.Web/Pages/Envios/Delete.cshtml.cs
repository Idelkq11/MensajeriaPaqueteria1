using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Application.Dtos;

namespace MensajeriaPaqueteria.Web.Pages.Envios
{
    public class DeleteModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public EnvioDto Envio { get; set; }

        public DeleteModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Envio = await _apiService.GetAsync<EnvioDto>($"Envio/{id}");
            if (Envio == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _apiService.DeleteAsync($"Envio/{id}");
            return RedirectToPage("Index");
        }
    }
}
