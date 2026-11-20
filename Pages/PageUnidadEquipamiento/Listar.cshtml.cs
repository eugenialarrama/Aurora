using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageUnidadEquipamiento
{
    public class ListarModel : PageModel
    {
        public List<UnidadEquipamiento> Unidades { get; set; }
        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Unidades = unaControladora.ListarUnidades();
        }
    }
}

