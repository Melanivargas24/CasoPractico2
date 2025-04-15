using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Universidad.Models;

public class DetailsModel : PageModel
{
    private readonly UniversidadDBContext _context;

    public DetailsModel(UniversidadDBContext context)
    {
        _context = context;
    }

    public Carrera Carrera { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Carrera = await _context.Carreras.FirstOrDefaultAsync(m => m.Id == id);

        if (Carrera == null)
            return NotFound();

        return Page();
    }
}
