
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MensajeriaPaqueteria.Pages
{
    public class UbicacionModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int MensajeroId { get; set; }

        public void OnGet()
        {
            // Puedes hacer algo con el ID aquí si necesitas
        }
    }
}
