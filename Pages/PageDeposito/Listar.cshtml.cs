using Aurora.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aurora.Pages.PageDeposito
{
    public class ListarModel : PageModel
    {
        public List<Deposito> Depositos { get; set; }
        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Depositos = unaControladora.ListarDepositos();
        }
    }
}

