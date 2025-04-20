using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Universidad.Models;

namespace Universidad.Pages.Cuenta
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<Usuario> _signInManager;

        public LogoutModel(SignInManager<Usuario> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _signInManager.SignOutAsync();
            TempData["LogoutMessage"] = "Cerraste sesión correctamente.";
            return RedirectToPage("/Index");
        }
    }
}