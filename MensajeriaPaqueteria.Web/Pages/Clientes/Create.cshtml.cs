using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Web.Pages.Clientes
{
    public class CreateModel(ApiService apiService) : PageModel
    {
        private readonly ApiService _apiService = apiService;

        [BindProperty]
        public ClienteDto Cliente { get; set; } = new ClienteDto();

        public string? ErrorMessage { get; set; }

        // Acción para procesar el POST
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Si el modelo no es válido, volvemos a mostrar la página
                return Page();
            }

            try
            {
                // Llamamos al servicio API para crear el cliente
                await _apiService.PostAsync<ClienteDto>("api/Cliente", Cliente);

                // Redirigimos a la página de lista de clientes después de crear el cliente
                return RedirectToPage("/Clientes/Index");
            }
            catch (Exception ex)
            {
                // Si ocurre un error, mostramos un mensaje
                ErrorMessage = $"Hubo un error al crear el cliente: {ex.Message}";
                return Page();
            }
        }
    }
}

