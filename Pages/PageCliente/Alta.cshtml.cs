using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageCliente
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; } = "";
        public void OnGet()
        {
        }
        public IActionResult OnPostAgregar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID del Cliente");
                }
                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID del cliente debe ser un numero");
                }
                if (Request.Form["tipo"] == "")
                {
                    throw new Exception("Debe seleccionar el tipo de cliente");
                }
                if (Request.Form["nombre"] == "")
                {
                    throw new Exception("Debe ingresar el nombre del cliente");
                }
                if (Request.Form["documento"] == "")
                {
                    throw new Exception("Debe ingresar el documento del cliente");
                }
                if (Request.Form["telefono"] == "")
                {
                    throw new Exception("Debe ingresar el teléfono del cliente");
                }
                if (Request.Form["email"] == "")
                {
                    throw new Exception("Debe ingresar el email del cliente");
                }
                if (Request.Form["direccion"] == "")
                {
                    throw new Exception("Debe ingresar la dirección del cliente");
                }

                int Id = int.Parse(Request.Form["id"]);
                string Tipo = Request.Form["tipo"];
                string Nombre = Request.Form["nombre"];
                string Documento = Request.Form["documento"];
                string Telefono = Request.Form["telefono"];
                string Email = Request.Form["email"];
                string Direccion = Request.Form["direccion"];

                Cliente unCliente = new Cliente(Id, Tipo, Nombre, Documento, Telefono, Email, Direccion);

                Controladora unaControladora = new Controladora();

                if (!unaControladora.AltaCliente(unCliente))
                {
                    throw new Exception("Ya existe un Cliente con ese ID");
                }
                return Redirect("/PageCliente/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}
