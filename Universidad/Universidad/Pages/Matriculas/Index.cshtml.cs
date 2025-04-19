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
    public class IndexModel : PageModel
    {
        private readonly Universidad.Models.UniversidadDBContext _context;

        public IndexModel(Universidad.Models.UniversidadDBContext context)
        {
            _context = context;
        }

        public IList<Matricula> Matricula { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Matricula = await _context.Matriculas
                .Include(m => m.Grupo)
                .ThenInclude(g => g.Materia)
                .Include(m => m.Usuario).ToListAsync();
        }
    }
}
