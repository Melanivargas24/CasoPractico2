using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Universidad.Models;

public class EditModel : PageModel
{
    private readonly UniversidadDBContext _context;

    public EditModel(UniversidadDBContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Carrera Carrera { get; set; }

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

        _context.Attach(Carrera).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Carreras.AnyAsync(e => e.Id == Carrera.Id))
                return NotFound();
            else
                throw;
        }

        return RedirectToPage("Index");
    }
}
