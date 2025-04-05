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
            Console.WriteLine($"[OnGet] Buscando env�o con ID: {id}");

            if (id <= 0)
            {
                Console.WriteLine("[OnGet] ID inv�lido.");
                return NotFound();
            }

            Envio = await _apiService.GetAsync<EnvioDto>($"Envio/{id}");
            if (Envio == null)
            {
                Console.WriteLine("[OnGet] No se encontr� el env�o en la API.");
                return NotFound();
            }

            Console.WriteLine($"[OnGet] Env�o encontrado: ID {Envio.EnvioId}");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("[OnPost] ModelState no es v�lido.");
                return Page();
            }

            if (Envio == null || Envio.EnvioId <= 0)
            {
                Console.WriteLine("[OnPost] Env�o nulo o ID inv�lido.");
                return BadRequest("ID del env�o no v�lido.");
            }

            Console.WriteLine($"[OnPost] Intentando actualizar env�o con ID: {Envio.EnvioId}");

            try
            {
                await _apiService.PutAsync<EnvioDto>($"Envio/{Envio.EnvioId}", Envio);
                Console.WriteLine("[OnPost] Actualizaci�n exitosa.");
                return RedirectToPage("Index");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"[OnPost] Error al actualizar el env�o: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Error al actualizar el env�o.");
                return Page();
            }
        }
    }
}
