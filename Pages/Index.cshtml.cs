using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            unaControladora.CargarListas();
        }
    }
}
