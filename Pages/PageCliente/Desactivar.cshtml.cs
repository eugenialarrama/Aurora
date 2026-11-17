using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageCliente
{
    public class DesactivarModel : PageModel
    {
         public Cliente cliente { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            cliente = unaControladora.BuscarCliente(id);
        }

        public IActionResult OnPostDesactivar()
        {
            int Id = int.Parse(Request.Form["id"]);

            Controladora unaControladora = new Controladora();
            unaControladora.DesactivarCliente(Id);
            return Redirect("/PageCliente/Listar");
        }
    }
}
