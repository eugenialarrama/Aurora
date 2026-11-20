using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageUnidadEquipamiento
{
    public class ModificarModel : PageModel
    {
        public UnidadEquipamiento unidad { get; set; }
        public List<TipoEquipamiento> Tipos { get; set; }
        public List<Deposito> Depositos { get; set; }
        public List<string> Estados { get; set; }
        public string Mensaje { get; set; } = "";

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            unidad = unaControladora.BuscarUnidad(id);
            Tipos = unaControladora.ListarTiposEquipamiento();
            Depositos = unaControladora.ListarDepositos();
            Estados = unaControladora.ListarEstados();
        }

        public IActionResult OnPostModificar()
        {
            Controladora unaControladora = new Controladora();
            unidad = unaControladora.BuscarUnidad(int.Parse(Request.Form["id"]));
            Tipos = unaControladora.ListarTiposEquipamiento();
            Depositos = unaControladora.ListarDepositos();
            Estados = unaControladora.ListarEstados();

            try
            {
                if (Request.Form["identificador"] == "")
                {
                    throw new Exception("Debe ingresar el Identificador de la Unidad");
                }
                if (Request.Form["estado"] == "")
                {
                    throw new Exception("Debe seleccionar el Estado de la Unidad");
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
                string Estado = Request.Form["estado"];
                TipoEquipamiento unTipo = unaControladora.BuscarTipoEquipamiento(int.Parse(Request.Form["idTipo"]));
                Deposito unDeposito = unaControladora.BuscarDeposito(int.Parse(Request.Form["idDeposito"]));

                UnidadEquipamiento OtraUnidad = unaControladora.BuscarUnidadPorIdentificador(Identificador);
                if (OtraUnidad != null && OtraUnidad.Id != Id)
                {
                    throw new Exception("Ya existe otra Unidad con ese Identificador");
                }

                unaControladora.ModificarUnidad(Id, Identificador, Estado, unTipo, unDeposito);
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
