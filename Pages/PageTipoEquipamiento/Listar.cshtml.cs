using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageTipoEquipamiento
{
    public class ListarModel : PageModel
    {
        public List<TipoEquipamiento> Tipos { get; set; }
        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Tipos = unaControladora.ListarTiposEquipamiento();
        }
    }
}

