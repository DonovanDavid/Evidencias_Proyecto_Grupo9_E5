using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Taller.App.Front.Pages
{
    public class LoginModel : PageModel
    {

        public string tituloLogin{get; set;}="Log prueba";

        public void OnGet()
        {
            tituloLogin = $" Server time is { DateTime.Now }";
        }
    }
}
