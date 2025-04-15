using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Models;
using System.Threading.Tasks;
using System.Linq;

public class EditModel : PageModel
{
    private readonly UniversidadDBContext _context;

    public EditModel(UniversidadDBContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Carrera Carrera { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Carrera = await _context.Carreras.FindAsync(id);

        if (Carrera == null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var existe = await _context.Carreras
            .AnyAsync(c => c.Id != Carrera.Id && c.Nombre.ToLower() == Carrera.Nombre.ToLower());

        if (existe)
        {
            ModelState.AddModelError(string.Empty, "Ya existe una carrera con ese nombre.");
            return Page();
        }

        var carreraOriginal = await _context.Carreras.FindAsync(Carrera.Id);
        if (carreraOriginal == null)
            return NotFound();

        carreraOriginal.Nombre = Carrera.Nombre;

        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}