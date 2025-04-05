using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Application.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MensajeriaPaqueteria.Web.Pages.Mensajeros
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public List<MensajeroDto> Mensajero { get; set; } = new List<MensajeroDto>();

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            var mensajero = await _apiService.GetAsync<List<MensajeroDto>>("Mensajero");
            if (mensajero != null)
            {
                Mensajero = mensajero;
            }
        }
    }
}
