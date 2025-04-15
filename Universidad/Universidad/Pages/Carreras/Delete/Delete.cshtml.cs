using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Universidad.Models;

public class DeleteModel : PageModel
{
    private readonly UniversidadDBContext _context;

    public DeleteModel(UniversidadDBContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Carrera Carrera { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Carrera = await _context.Carreras.FirstOrDefaultAsync(m => m.Id == id);
        if (Carrera == null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var carrera = await _context.Carreras.FindAsync(Carrera.Id);
        if (carrera == null)
            return NotFound();

        _context.Carreras.Remove(carrera);
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
