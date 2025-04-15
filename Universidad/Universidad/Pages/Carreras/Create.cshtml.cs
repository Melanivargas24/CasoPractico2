using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Universidad.Models;
using Microsoft.EntityFrameworkCore;

public class CreateModel : PageModel
{
    private readonly UniversidadDBContext _context;

    public CreateModel(UniversidadDBContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Carrera Carrera { get; set; }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        bool existe = await _context.Carreras
            .AnyAsync(c => c.Nombre.ToLower() == Carrera.Nombre.ToLower());

        if (existe)
        {
            ModelState.AddModelError(string.Empty, "Ya existe una carrera con ese nombre.");
            return Page();
        }

        _context.Carreras.Add(Carrera);
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
