using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Universidad.Models;

namespace Universidad.Pages.Grupos
{
    public class DetailsModel : PageModel
    {
        private readonly UniversidadDBContext _context;

        public DetailsModel(UniversidadDBContext context)
        {
            _context = context;
        }

        public Grupo Grupo { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Grupo = await _context.Grupos
                .Include(g => g.Materia)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (Grupo == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}