using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageDeposito
{
    public class EliminarModel : PageModel
    {
            public Deposito deposito { get; set; }
            public string Mensaje { get; set; } = "";

            public void OnGet(int id)
            {
                Controladora unaControladora = new Controladora();
                deposito = unaControladora.BuscarDeposito(id);
            }

            public IActionResult OnPostEliminar()
            {
                int Id = int.Parse(Request.Form["id"]);

                Controladora unaControladora = new Controladora();
                if (!unaControladora.BajaDeposito(Id))
                {
                    deposito = unaControladora.BuscarDeposito(Id);
                    Mensaje = Mensaje = "No se puede eliminar el Depósito porque tiene Tipos de Equipamiento o Unidades asignados"; 
                    return Page();
                }
                return Redirect("/PageDeposito/Listar");
            }
        }
    }


