using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Universidad.Models;

namespace Universidad.Pages.Grupos
{
    public class IndexModel : PageModel
    {
        private readonly UniversidadDBContext _context;

        public IndexModel(UniversidadDBContext context)
        {
            _context = context;
        }

        public List<Grupo> Grupos { get; set; } = new();

        public async Task OnGetAsync()
        {
            Grupos = await _context.Grupos
                .Include(g => g.Materia)
                .ToListAsync();
        }
    }
}