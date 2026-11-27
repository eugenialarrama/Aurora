using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageSolicitud
{
    public class DetalleModel : PageModel
    {
        public SolicitudAlquiler solicitud { get; set; }

        public IActionResult OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            unaControladora.ListarSolicitudes();
            solicitud = unaControladora.BuscarSolicitud(id);

            if (solicitud == null)
            {
                return Redirect("/PageSolicitud/Listar");
            }
            return Page();
        }
    }
}
