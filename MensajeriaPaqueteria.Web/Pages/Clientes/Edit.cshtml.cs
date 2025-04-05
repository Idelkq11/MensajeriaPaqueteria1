using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MensajeriaPaqueteria.Web.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public ClienteDto Cliente { get; set; }

        public EditModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        // Cargar los datos del cliente en el formulario
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id <= 0) // Validación para evitar IDs inválidos
            {
                return NotFound();
            }

            Cliente = await _apiService.GetAsync<ClienteDto>($"Cliente/{id}");

            if (Cliente == null)
            {
                return NotFound(); // Si no se encuentra el cliente, muestra un error 404
            }

            return Page();
        }

        // Guardar los cambios cuando el usuario envía el formulario
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Si hay errores de validación, vuelve a mostrar la página
            }

            if (Cliente.ClienteId <= 0) // Validación adicional para asegurarse de que el ID es válido
            {
                ModelState.AddModelError("", "El ID del cliente no es válido.");
                return Page();
            }

            // Depuración: Verificar que el ID no sea 0 antes de hacer la solicitud
            Console.WriteLine($"Actualizando Cliente ID: {Cliente.ClienteId}");

            await _apiService.PutAsync<ClienteDto>($"Cliente/{Cliente.ClienteId}", Cliente);

            return RedirectToPage("Index");
        }
    }
}