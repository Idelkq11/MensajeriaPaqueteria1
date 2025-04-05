using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Web.Services;
using System;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Web.Pages.Envios
{
    public class EditModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public EnvioDto Envio { get; set; }

        public EditModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Console.WriteLine($"[OnGet] Buscando envío con ID: {id}");

            if (id <= 0)
            {
                Console.WriteLine("[OnGet] ID inválido.");
                return NotFound();
            }

            Envio = await _apiService.GetAsync<EnvioDto>($"Envio/{id}");
            if (Envio == null)
            {
                Console.WriteLine("[OnGet] No se encontró el envío en la API.");
                return NotFound();
            }

            Console.WriteLine($"[OnGet] Envío encontrado: ID {Envio.EnvioId}");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("[OnPost] ModelState no es válido.");
                return Page();
            }

            if (Envio == null || Envio.EnvioId <= 0)
            {
                Console.WriteLine("[OnPost] Envío nulo o ID inválido.");
                return BadRequest("ID del envío no válido.");
            }

            Console.WriteLine($"[OnPost] Intentando actualizar envío con ID: {Envio.EnvioId}");

            try
            {
                await _apiService.PutAsync<EnvioDto>($"Envio/{Envio.EnvioId}", Envio);
                Console.WriteLine("[OnPost] Actualización exitosa.");
                return RedirectToPage("Index");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"[OnPost] Error al actualizar el envío: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Error al actualizar el envío.");
                return Page();
            }
        }
    }
}
