using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Universidad.Models;

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
            return Page();

        _context.Carreras.Add(Carrera);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
