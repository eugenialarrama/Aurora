using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageUnidadEquipamiento
{
    public class EliminarModel : PageModel
    {
        public UnidadEquipamiento unidad { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            unidad = unaControladora.BuscarUnidad(id);
        }

        public IActionResult OnPostEliminar()
        {
            int Id = int.Parse(Request.Form["id"]);

            Controladora unaControladora = new Controladora();
            unaControladora.BajaUnidad(Id);
            return Redirect("/PageUnidadEquipamiento/Listar");
        }
    }
}
