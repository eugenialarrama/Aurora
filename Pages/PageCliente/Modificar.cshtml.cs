using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageCliente
{
    public class ModificarModel : PageModel
    {
        public Cliente cliente { get; set; }
        public string Mensaje { get; set; } = "";

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            cliente = unaControladora.BuscarCliente(id);
        }

        public IActionResult OnPostModificar()
        {
            Controladora unaControladora = new Controladora();
            cliente = unaControladora.BuscarCliente(int.Parse(Request.Form["id"]));

            try
            {
                if (Request.Form["tipo"] == "")
                {
                    throw new Exception("Debe seleccionar el Tipo de Cliente");
                }
                if (Request.Form["nombre"] == "")
                {
                    throw new Exception("Debe ingresar el Nombre del Cliente");
                }
                if (Request.Form["documento"] == "")
                {
                    throw new Exception("Debe ingresar el Documento del Cliente");
                }
                if (Request.Form["telefono"] == "")
                {
                    throw new Exception("Debe ingresar el Teléfono del Cliente");
                }
                if (Request.Form["email"] == "")
                {
                    throw new Exception("Debe ingresar el Email del Cliente");
                }
                if (Request.Form["direccion"] == "")
                {
                    throw new Exception("Debe ingresar la Dirección del Cliente");
                }

                int Id = int.Parse(Request.Form["id"]);
                string Tipo = Request.Form["tipo"];
                string Nombre = Request.Form["nombre"];
                string Documento = Request.Form["documento"];
                string Telefono = Request.Form["telefono"];
                string Email = Request.Form["email"];
                string Direccion = Request.Form["direccion"];

                unaControladora.ModificarCliente(Id, Tipo, Nombre, Documento, Telefono, Email, Direccion);
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
