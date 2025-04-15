using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Models;

namespace Universidad.Pages.Materias
{
    public class DetailsModel : PageModel
    {
        private readonly UniversidadDBContext _context;

        public DetailsModel(UniversidadDBContext context)
        {
            _context = context;
        }

        public Materia Materia { get; set; } = null!;
        public List<Carrera> Carreras { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Materia = await _context.Materias
                .Include(m => m.MateriasCarreras)
                    .ThenInclude(mc => mc.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Materia == null)
            {
                return NotFound();
            }

            Carreras = Materia.MateriasCarreras.Select(mc => mc.Carrera).ToList();
            return Page();
        }
    }
}