using MensajeriaPaqueteria.Web.Services; 
using MensajeriaPaqueteria.Application.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace MensajeriaPaqueteria.Web.Pages.Envios
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public List<EnvioDto> Envios { get; set; } = new ();

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
           Envios = await _apiService.GetAsync<List<EnvioDto>>("Envio");
           
            
                
            
        }
    }
}
