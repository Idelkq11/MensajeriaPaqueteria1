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
            if (id <= 0) // Validaci�n para evitar IDs inv�lidos
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

        // Guardar los cambios cuando el usuario env�a el formulario
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Si hay errores de validaci�n, vuelve a mostrar la p�gina
            }

            if (Cliente.ClienteId <= 0) // Validaci�n adicional para asegurarse de que el ID es v�lido
            {
                ModelState.AddModelError("", "El ID del cliente no es v�lido.");
                return Page();
            }

            // Depuraci�n: Verificar que el ID no sea 0 antes de hacer la solicitud
            Console.WriteLine($"Actualizando Cliente ID: {Cliente.ClienteId}");

            await _apiService.PutAsync<ClienteDto>($"Cliente/{Cliente.ClienteId}", Cliente);

            return RedirectToPage("Index");
        }
    }
}