using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Web.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public ClienteDto Cliente { get; set; } = new ClienteDto();

        public List<PaqueteDto> Paquetes { get; set; }
        public List<MensajeroDto> Mensajero { get; set; }

        public CreateModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            // Obtener listas de datos antes de mostrar la vista
            Paquetes = await _apiService.GetAsync<List<PaqueteDto>>("Paquetes");
            Mensajero= await _apiService.GetAsync<List<MensajeroDto>>("Mensajero");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            await _apiService.PostAsync<ClienteDto>("Cliente", Cliente);
            return RedirectToPage("Index");
        }
    }
}




     
   

  

            

            
   


