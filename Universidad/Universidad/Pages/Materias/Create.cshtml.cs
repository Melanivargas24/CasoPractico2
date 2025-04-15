using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universidad.Models;

namespace Universidad.Pages.Materias
{
    public class CreateModel : PageModel
    {
        private readonly UniversidadDBContext _context;

        public CreateModel(UniversidadDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Materia Materia { get; set; } = new();

        [BindProperty]
        public List<int> SelectedCarreras { get; set; } = new();

        public MultiSelectList CarrerasSelectList { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync()
        {
            var carreras = await _context.Carreras.ToListAsync();
            CarrerasSelectList = new MultiSelectList(carreras, "Id", "Nombre");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var carreras = await _context.Carreras.ToListAsync();
                CarrerasSelectList = new MultiSelectList(carreras, "Id", "Nombre");
                return Page();
            }

            _context.Materias.Add(Materia);
            await _context.SaveChangesAsync();

            foreach (var carreraId in SelectedCarreras)
            {
                _context.MateriasCarreras.Add(new MateriaCarrera
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