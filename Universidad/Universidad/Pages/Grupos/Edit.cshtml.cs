using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Universidad.Models;

namespace Universidad.Pages.Grupos
{
    public class EditModel : PageModel
    {
        private readonly UniversidadDBContext _context;

        public EditModel(UniversidadDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Grupo Grupo { get; set; } = null!;

        public SelectList MateriasSelectList { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Grupo = await _context.Grupos
                .Include(g => g.Materia)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (Grupo == null)
            {
                return NotFound();
            }

            var materias = await _context.Materias.ToListAsync();
            MateriasSelectList = new SelectList(materias, "Id", "Nombre", Grupo.MateriaId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var materias = await _context.Materias.ToListAsync();
                MateriasSelectList = new SelectList(materias, "Id", "Nombre", Grupo.MateriaId);
                return Page();
            }

            _context.Attach(Grupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Grupos.Any(e => e.Id == Grupo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }
    }
}