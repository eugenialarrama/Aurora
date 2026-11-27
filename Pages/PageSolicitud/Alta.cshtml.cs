using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageSolicitud
{
    public class AltaModel : PageModel
    {
        public List<Cliente> Clientes { get; set; }
        public List<TipoEquipamiento> Tipos { get; set; }
        public List<LineaSolicitud> Lineas { get; set; }
        public string Mensaje { get; set; } = "";

        [BindProperty] public int idCliente { get; set; }
        [BindProperty] public string nombre { get; set; }
        [BindProperty] public string fecha { get; set; }
        [BindProperty] public string ubicacion { get; set; }
        [BindProperty] public string horaInicio { get; set; }
        [BindProperty] public string horaFin { get; set; }
        [BindProperty] public string asistentes { get; set; }
        [BindProperty] public int idTipo { get; set; }
        [BindProperty] public int Cantidad { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            unaControladora.LimpiarLineasSolicitud();
            CargarDatos();
        }

        private void CargarDatos()
        {
            Controladora unaControladora = new Controladora();
            Clientes = unaControladora.ListarClientes();
            Tipos = unaControladora.ListarTiposEquipamiento();
            Lineas = unaControladora.ListarLineasSolicitud();
        }
        public int Disponibles(int pIdTipo)
        {
            Controladora unaControladora = new Controladora();
            return unaControladora.CantidadDisponible(pIdTipo);
        }

        public IActionResult OnPostAgregarLinea()
        {
            CargarDatos();
            Controladora unaControladora = new Controladora();

            try
            {
                if (idTipo == 0)
                {
                    throw new Exception("Debe seleccionar un Tipo de equipamiento");
                }
                if (Cantidad <= 0)
                {
                    throw new Exception("La cantidad debe ser mayor a 0");
                }

                TipoEquipamiento unTipo = unaControladora.BuscarTipoEquipamiento(idTipo);
                if (unTipo == null)
                {
                    throw new Exception("El tipo de equipamiento no existe");
                }

                int CantDisponible = unaControladora.CantidadDisponible(idTipo);
                if (Cantidad > CantDisponible)
                {
                    throw new Exception("No hay suficientes unidades disponibles de " + unTipo.Nombre + " (hay " + CantDisponible + ")");
                }

                int idLinea = unaControladora.ProximoIdLinea();
                foreach (LineaSolicitud unaLinea in unaControladora.ListarLineasSolicitud())
                {
                    if (unaLinea.Tipo.Id == idTipo)
                    {
                        throw new Exception("Ese tipo de equipamiento ya fue agregado a la solicitud");
                    }
                    if (unaLinea.Id >= idLinea)
                    {
                        idLinea = unaLinea.Id + 1;
                    }
                }

                LineaSolicitud nuevaLinea = new LineaSolicitud(idLinea, unTipo, Cantidad);
                unaControladora.AltaLineaSolicitud(nuevaLinea);

                idTipo = 0;
                Cantidad = 0;
                ModelState.Remove("idTipo");
                ModelState.Remove("Cantidad");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
            }
            return Page();
        }

        public IActionResult OnPostQuitarLinea(int id)
        {
            CargarDatos();
            Controladora unaControladora = new Controladora();
            unaControladora.QuitarLineaSolicitud(id);
            return Page();
        }

        public IActionResult OnPostAgregar()
        {
            CargarDatos();
            Controladora unaControladora = new Controladora();

            try
            {
                if (Request.Form["idCliente"] == "")
                {
                    throw new Exception("Debe seleccionar un Cliente");
                }
                if (Request.Form["nombre"] == "")
                {
                    throw new Exception("Debe ingresar el Nombre del Evento");
                }
                if (Request.Form["fecha"] == "")
                {
                    throw new Exception("Debe ingresar la Fecha del Evento");
                }
                if (Request.Form["ubicacion"] == "")
                {
                    throw new Exception("Debe ingresar la Ubicación del Evento");
                }
                if (Request.Form["horaInicio"] == "")
                {
                    throw new Exception("Debe ingresar la Hora de inicio");
                }
                if (Request.Form["horaFin"] == "")
                {
                    throw new Exception("Debe ingresar la Hora de fin");
                }
                if (Request.Form["asistentes"] == "")
                {
                    throw new Exception("Debe ingresar la Cantidad de asistentes");
                }
                if (!int.TryParse(Request.Form["asistentes"], out _))
                {
                    throw new Exception("La Cantidad de asistentes debe ser un numero");
                }

                DateTime Fecha = DateTime.Parse(Request.Form["fecha"]);
                TimeSpan HoraInicio = TimeSpan.Parse(Request.Form["horaInicio"]);
                TimeSpan HoraFin = TimeSpan.Parse(Request.Form["horaFin"]);
                int Asistentes = int.Parse(Request.Form["asistentes"]);

                if (Fecha < DateTime.Today)
                {
                    throw new Exception("La fecha del evento no puede ser anterior a hoy");
                }
                if (HoraFin <= HoraInicio)
                {
                    throw new Exception("La hora de fin debe ser posterior a la hora de inicio");
                }
                if (Asistentes <= 0)
                {
                    throw new Exception("La cantidad de asistentes debe ser mayor a 0");
                }
                if (unaControladora.ListarLineasSolicitud().Count == 0)
                {
                    throw new Exception("Debe agregar al menos un Tipo de equipamiento a la solicitud");
                }

                Cliente unCliente = unaControladora.BuscarCliente(int.Parse(Request.Form["idCliente"]));
                string Nombre = Request.Form["nombre"];
                string Ubicacion = Request.Form["ubicacion"];

                Evento unEvento = new Evento(unaControladora.ProximoIdEvento(), Nombre, Fecha, Ubicacion, HoraInicio, HoraFin, Asistentes);
                SolicitudAlquiler unaSolicitud = new SolicitudAlquiler(unaControladora.ProximoIdSolicitud(), DateTime.Today, "Pendiente", unCliente, unEvento);
                unaSolicitud.Lineas = new List<LineaSolicitud>(unaControladora.ListarLineasSolicitud());

                if (!unaControladora.AltaSolicitud(unaSolicitud))
                {
                    throw new Exception("No se pudo registrar la solicitud");
                }
                return Redirect("/PageSolicitud/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
     
    }
}