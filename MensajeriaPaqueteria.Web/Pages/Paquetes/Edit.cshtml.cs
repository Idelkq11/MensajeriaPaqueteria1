using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Web.Services;
using MensajeriaPaqueteria.Domain.Entities;
using System.Threading.Tasks;
using System.Net.Http;

namespace MensajeriaPaqueteria.Web.Pages.Paquetes
{
    public class EditModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public Paquete Paquete { get; set; }

        public EditModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Paquete = await _apiService.GetAsync<Paquete>($"Paquetes/{id}");

                if (Paquete == null)
                {
                    ModelState.AddModelError(string.Empty, "El paquete no fue encontrado.");
                    return NotFound();
                }

                return Page();
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al obtener los datos del paquete: {ex.Message}");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                if (Paquete.PaqueteId <= 0)
                {
                    ModelState.AddModelError(string.Empty, "El ID del paquete es inválido.");
                    return Page();
                }

                var response = await _apiService.PutAsync<Paquete>($"Paquetes/{Paquete.PaqueteId}", Paquete);

                if (response == null)
                {
                    ModelState.AddModelError(string.Empty, "No se pudo actualizar el paquete. Verifica que el ID sea correcto.");
                    return Page();
                }

                return RedirectToPage("Index");
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al actualizar los datos del paquete: {ex.Message}");
                return Page();
            }
        }
    }
}
