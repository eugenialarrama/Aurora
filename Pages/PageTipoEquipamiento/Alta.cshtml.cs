using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageTipoEquipamiento
{
    public class AltaModel : PageModel
    {
        public List<Deposito> Depositos { get; set; }
        public string Mensaje { get; set; } = "";

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Depositos = unaControladora.ListarDepositos();
        }

        public IActionResult OnPostAgregar()
        {
            Controladora unaControladora = new Controladora();
            Depositos = unaControladora.ListarDepositos();

            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID del Tipo de Equipamiento");
                }
                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID del Tipo de Equipamiento debe ser un numero");
                }
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

                TipoEquipamiento unTipo = new TipoEquipamiento(Id, Nombre, Descripcion, Caracteristicas, Precio, unDeposito);

                if (!unaControladora.AltaTipoEquipamiento(unTipo))
                {
                    throw new Exception("Ya existe un Tipo de Equipamiento con ese ID");
                }
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

