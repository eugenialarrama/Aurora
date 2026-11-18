using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageTipoEquipamiento
{
    public class EliminarModel : PageModel
    {
        public TipoEquipamiento tipo { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            tipo = unaControladora.BuscarTipoEquipamiento(id);
        }

        public IActionResult OnPostEliminar()
        {
            int Id = int.Parse(Request.Form["id"]);

            Controladora unaControladora = new Controladora();
            unaControladora.BajaTipoEquipamiento(Id);
            return Redirect("/PageTipoEquipamiento/Listar");
        }
    }
}

