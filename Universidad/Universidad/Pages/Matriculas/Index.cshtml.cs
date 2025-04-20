using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Universidad.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Universidad.Pages.Matriculas
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UniversidadDBContext _context;
        private readonly UserManager<Usuario> _userManager;

        public IndexModel(UniversidadDBContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Matricula> Matricula { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Cuenta/Login");
            }

            var usuario = await _userManager.GetUserAsync(User);
            if (usuario == null)
            {
                return RedirectToPage("/Cuenta/Login");
            }

            if (User.IsInRole("Administrador"))
            {
                // Admin: ver todas las matrículas
                Matricula = await _context.Matriculas
                    .Include(m => m.Usuario)
                    .Include(m => m.Grupo)
                        .ThenInclude(g => g.Materia)
                    .ToListAsync();
            }
            else
            {
                // Estudiante: ver solo sus matrículas
                Matricula = await _context.Matriculas
                    .Where(m => m.UsuarioId == usuario.Id)
                    .Include(m => m.Usuario)
                    .Include(m => m.Grupo)
                        .ThenInclude(g => g.Materia)
                    .ToListAsync();
            }

            return Page();
        }
    }
}