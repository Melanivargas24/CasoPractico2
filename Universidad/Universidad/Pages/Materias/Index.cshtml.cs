using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Universidad.Pages.Materias
{
    public class IndexModel : PageModel
    {
        private readonly UniversidadDBContext _context;

        public IndexModel(UniversidadDBContext context)
        {
            _context = context;
        }

        public List<Materia> Materias { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Materias = await _context.Materias
                .Include(m => m.MateriasCarreras!)
                    .ThenInclude(mc => mc.Carrera)
                .ToListAsync();

            return Page();
        }
    }
}