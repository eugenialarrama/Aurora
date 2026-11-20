using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageTipoEquipamiento
{
    public class EliminarModel : PageModel
    {
        public TipoEquipamiento tipo { get; set; }
        public string Mensaje { get; set; } = "";

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            tipo = unaControladora.BuscarTipoEquipamiento(id);
        }

        public IActionResult OnPostEliminar()
        {
            int Id = int.Parse(Request.Form["id"]);

            Controladora unaControladora = new Controladora();
            if (!unaControladora.BajaTipoEquipamiento(Id))
            {
                tipo = unaControladora.BuscarTipoEquipamiento(Id);
                Mensaje = "No se puede eliminar el Tipo de Equipamiento porque tiene Unidades asignadas";
                return Page();
            }
            return Redirect("/PageTipoEquipamiento/Listar");
        }
    }
}