using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageDeposito
{
    public class ModificarModel : PageModel
    {
        public Deposito deposito { get; set; }
        public string Mensaje { get; set; } = "";

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            deposito = unaControladora.BuscarDeposito(id);
        }

        public IActionResult OnPostModificar()
        {
            Controladora unaControladora = new Controladora();
            deposito = unaControladora.BuscarDeposito(int.Parse(Request.Form["id"]));

            try
            {
                if (Request.Form["nombre"] == "")
                {
                    throw new Exception("Debe ingresar el Nombre del Depósito");
                }
                if (Request.Form["direccion"] == "")
                {
                    throw new Exception("Debe ingresar la Dirección del Depósito");
                }

                int Id = int.Parse(Request.Form["id"]);
                string Nombre = Request.Form["nombre"];
                string Direccion = Request.Form["direccion"];

                unaControladora.ModificarDeposito(Id, Nombre, Direccion);
                return Redirect("/PageDeposito/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}

