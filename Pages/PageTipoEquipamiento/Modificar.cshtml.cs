using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageTipoEquipamiento
{
    public class ModificarModel : PageModel
    {
        public TipoEquipamiento tipo { get; set; }
        public List<Deposito> Depositos { get; set; }
        public string Mensaje { get; set; } = "";

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            tipo = unaControladora.BuscarTipoEquipamiento(id);
            Depositos = unaControladora.ListarDepositos();
        }

        public IActionResult OnPostModificar()
        {
            Controladora unaControladora = new Controladora();
            tipo = unaControladora.BuscarTipoEquipamiento(int.Parse(Request.Form["id"]));
            Depositos = unaControladora.ListarDepositos();

            try
            {
                if (Request.Form["nombre"] == "")
                {
                    throw new Exception("Debe ingresar el Nombre del Tipo de Equipamiento");
                }
                if (Request.Form["descripcion"] == "")
                {
                    throw new Exception("Debe ingresar la Descripción del Tipo de Equipamiento");
                }
                if (Request.Form["caracteristicas"] == "")
                {
                    throw new Exception("Debe ingresar las Características del Tipo de Equipamiento");
                }
                if (Request.Form["precio"] == "")
                {
                    throw new Exception("Debe ingresar el Precio de alquiler");
                }
                if (!decimal.TryParse(Request.Form["precio"], out _))
                {
                    throw new Exception("El Precio de alquiler debe ser un numero");
                }
                if (decimal.Parse(Request.Form["precio"]) <= 0)
                {
                    throw new Exception("El Precio de alquiler debe ser mayor a 0");
                }
                if (Request.Form["idDeposito"] == "")
                {
                    throw new Exception("Debe seleccionar un Depósito");
                }

                int Id = int.Parse(Request.Form["id"]);
                string Nombre = Request.Form["nombre"];
                string Descripcion = Request.Form["descripcion"];
                string Caracteristicas = Request.Form["caracteristicas"];
                decimal Precio = decimal.Parse(Request.Form["precio"]);
                Deposito unDeposito = unaControladora.BuscarDeposito(int.Parse(Request.Form["idDeposito"]));

                unaControladora.ModificarTipoEquipamiento(Id, Nombre, Descripcion, Caracteristicas, Precio, unDeposito);
                return Redirect("/PageTipoEquipamiento/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}

