using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Universidad.Models;

public class IndexModel : PageModel
{
    private readonly UniversidadDBContext _context;

    public IndexModel(UniversidadDBContext context)
    {
        _context = context;
    }

    public List<Carrera> Carreras { get; set; }

    public async Task OnGetAsync()
    {
        Carreras = await _context.Carreras.ToListAsync();
    }
}
