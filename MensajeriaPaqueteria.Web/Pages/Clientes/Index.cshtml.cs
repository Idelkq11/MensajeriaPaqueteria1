using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Application.Dtos;

namespace MensajeriaPaqueteria.Web.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public List<ClienteDto> Clientes { get; set; } = new();

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            Clientes = await _apiService.GetAsync<List<ClienteDto>>("Cliente");
        }
    }
}

