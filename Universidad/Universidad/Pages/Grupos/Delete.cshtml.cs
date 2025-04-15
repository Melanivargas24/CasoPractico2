using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Universidad.Models;

namespace Universidad.Pages.Grupos
{
    public class DeleteModel : PageModel
    {
        private readonly UniversidadDBContext _context;

        public DeleteModel(UniversidadDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Grupo Grupo { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Grupo = await _context.Grupos
                .Include(g => g.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Grupo == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var grupo = await _context.Grupos.FindAsync(id);

            if (grupo != null)
            {
                _context.Grupos.Remove(grupo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}