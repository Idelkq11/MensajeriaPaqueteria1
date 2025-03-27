using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services; 
using MensajeriaPaqueteria.Application.Dtos; 

namespace MensajeriaPaqueteria.Web.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public ClienteDto Cliente { get; set; }

        public DeleteModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Cliente = await _apiService.GetAsync<ClienteDto>($"Cliente/{id}");
            if (Cliente == null)
            {
              
                return NotFound();
            }

            return Page(); 
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            
            await _apiService.DeleteAsync($"Cliente/{id}");
            return RedirectToPage("Index"); 
        }
    }
}

