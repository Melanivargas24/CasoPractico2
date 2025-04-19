using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Models;

namespace Universidad.Pages.Matriculas
{
    public class EliminarModel : PageModel
    {
        private readonly Universidad.Models.UniversidadDBContext _context;

        public EliminarModel(Universidad.Models.UniversidadDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Matricula Matricula { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas.FirstOrDefaultAsync(m => m.Id == id);

            if (matricula is not null)
            {
                Matricula = matricula;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula != null)
            {
                Matricula = matricula;
                _context.Matriculas.Remove(Matricula);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Matriculas/Index");
        }
    }
}
