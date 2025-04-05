using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Domain.Entities;

namespace MensajeriaPaqueteria.Web.Pages.Paquetes
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public List<Paquete> Paquetes { get; set; }

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            Paquetes = await _apiService.GetAsync<List<Paquete>>("Paquetes");
        }
    }
}
