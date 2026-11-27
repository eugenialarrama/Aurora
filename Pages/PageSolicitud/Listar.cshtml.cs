using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageSolicitud
{
    public class ListarModel : PageModel
    {
        public List<SolicitudAlquiler> Solicitudes { get; set; }
        public string Mensaje { get; set; } = "";

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Solicitudes = unaControladora.ListarSolicitudes();
        }

        public IActionResult OnPostAceptar(int id)
        {
            Controladora unaControladora = new Controladora();
            unaControladora.ListarSolicitudes();
            SolicitudAlquiler unaSolicitud = unaControladora.BuscarSolicitud(id);

            if (unaSolicitud != null)
            {
                string Faltante = unaControladora.VerificarDisponibilidad(unaSolicitud);
                if (Faltante != "")
                {
                    Mensaje = Faltante;
                    Solicitudes = unaControladora.ListarSolicitudes();
                    return Page();
                }
            }
            CambiarEstado(id, "Aceptada");
            return Page();
        }
        

        public IActionResult OnPostRechazar(int id)
        {
            CambiarEstado(id, "Rechazada");
            return Page();
        }

        public IActionResult OnPostCancelar(int id)
        {
            CambiarEstado(id, "Cancelada");
            return Page();
        }

        private void CambiarEstado(int pId, string pEstado)
        {
            Controladora unaControladora = new Controladora();
            unaControladora.ListarSolicitudes();
            if (!unaControladora.CambiarEstadoSolicitud(pId, pEstado))
            {
                Mensaje = "No se pudo cambiar el estado de la solicitud";
            }
            Solicitudes = unaControladora.ListarSolicitudes();
        }
    }
}

