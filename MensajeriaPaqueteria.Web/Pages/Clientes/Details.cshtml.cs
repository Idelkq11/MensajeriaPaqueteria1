using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Domain.Entities;

namespace MensajeriaPaqueteria.Web.Pages.Clientes
{
    public class DetailsModel : PageModel
    {
        private readonly ApiService _apiService;

        public Cliente Cliente { get; set; }

        public DetailsModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Cliente = await _apiService.GetAsync<Cliente>($"Cliente/{id}");
            if (Cliente == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
