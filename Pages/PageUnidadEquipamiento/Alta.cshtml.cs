using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageUnidadEquipamiento
{
    public class AltaModel : PageModel
    {
        public List<TipoEquipamiento> Tipos { get; set; }
        public List<Deposito> Depositos { get; set; }
        public string Mensaje { get; set; } = "";

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Tipos = unaControladora.ListarTiposEquipamiento();
            Depositos = unaControladora.ListarDepositos();
        }

        public IActionResult OnPostAgregar()
        {
            Controladora unaControladora = new Controladora();
            Tipos = unaControladora.ListarTiposEquipamiento();
            Depositos = unaControladora.ListarDepositos();

            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID de la Unidad");
                }
                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID de la Unidad debe ser un numero");
                }
                if (Request.Form["identificador"] == "")
                {
                    throw new Exception("Debe ingresar el Identificador de la Unidad");
                }
                if (Request.Form["idTipo"] == "")
                {
                    throw new Exception("Debe seleccionar un Tipo de Equipamiento");
                }
                if (Request.Form["idDeposito"] == "")
                {
                    throw new Exception("Debe seleccionar un Depósito");
                }

                int Id = int.Parse(Request.Form["id"]);
                string Identificador = Request.Form["identificador"];
                TipoEquipamiento unTipo = unaControladora.BuscarTipoEquipamiento(int.Parse(Request.Form["idTipo"]));
                Deposito unDeposito = unaControladora.BuscarDeposito(int.Parse(Request.Form["idDeposito"]));

                if (unaControladora.BuscarUnidadPorIdentificador(Identificador) != null)
                {
                    throw new Exception("Ya existe una Unidad con ese Identificador");
                }

                UnidadEquipamiento unaUnidad = new UnidadEquipamiento(Id, Identificador, "Disponible", unTipo, unDeposito);

                if (!unaControladora.AltaUnidad(unaUnidad))
                {
                    throw new Exception("Ya existe una Unidad con ese ID");
                }
                return Redirect("/PageUnidadEquipamiento/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}

