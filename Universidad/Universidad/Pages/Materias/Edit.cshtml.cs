using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universidad.Models;

namespace Universidad.Pages.Materias
{
    public class EditModel : PageModel
    {
        private readonly UniversidadDBContext _context;

        public EditModel(UniversidadDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Materia Materia { get; set; } = new();

        [BindProperty]
        public List<int> SelectedCarreras { get; set; } = new();

        public MultiSelectList CarrerasSelectList { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Materia = await _context.Materias
                .Include(m => m.MateriasCarreras)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Materia == null)
            {
                return NotFound();
            }

            SelectedCarreras = Materia.MateriasCarreras.Select(mc => mc.CarreraId).ToList();

            var carreras = await _context.Carreras.ToListAsync();
            CarrerasSelectList = new MultiSelectList(carreras, "Id", "Nombre", SelectedCarreras);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var carreras = await _context.Carreras.ToListAsync();
                CarrerasSelectList = new MultiSelectList(carreras, "Id", "Nombre", SelectedCarreras);
                return Page();
            }

            var materiaToUpdate = await _context.Materias
                .Include(m => m.MateriasCarreras)
                .FirstOrDefaultAsync(m => m.Id == Materia.Id);

            if (materiaToUpdate == null)
            {
                return NotFound();
            }

            materiaToUpdate.Nombre = Materia.Nombre;

            materiaToUpdate.MateriasCarreras.Clear();
            foreach (var carreraId in SelectedCarreras)
            {
                materiaToUpdate.MateriasCarreras.Add(new MateriaCarrera
                {
                    MateriaId = Materia.Id,
                    CarreraId = carreraId
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}