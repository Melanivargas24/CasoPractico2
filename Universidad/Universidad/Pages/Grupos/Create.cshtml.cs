using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Universidad.Models;

namespace Universidad.Pages.Grupos
{
    public class CreateModel : PageModel
    {
        private readonly UniversidadDBContext _context;

        public CreateModel(UniversidadDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Grupo Grupo { get; set; } = new();

        public SelectList MateriasSelectList { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync()
        {
            var materias = await _context.Materias.ToListAsync();
            MateriasSelectList = new SelectList(materias, "Id", "Nombre");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine($"[DEBUG] MateriaId: {Grupo.MateriaId}");
            Console.WriteLine($"[DEBUG] Horario: {Grupo.Horario}");
            Console.WriteLine($"[DEBUG] ModelState.IsValid: {ModelState.IsValid}");


                if (!ModelState.IsValid)
                {

                    foreach (var entry in ModelState)
                    {
                        foreach (var error in entry.Value.Errors)
                        {
                            Console.WriteLine($"[MODEL ERROR] {entry.Key}: {error.ErrorMessage}");
                        }
                    }

                    var materias = await _context.Materias.ToListAsync();
                    MateriasSelectList = new SelectList(materias, "Id", "Nombre");
                    return Page();
                }

                var materiaExiste = await _context.Materias.AnyAsync(m => m.Id == Grupo.MateriaId);

                if (!materiaExiste)
                {
                    ModelState.AddModelError("Grupo.MateriaId", "La materia seleccionada no es válida.");
                    var materias = await _context.Materias.ToListAsync();
                    MateriasSelectList = new SelectList(materias, "Id", "Nombre");
                    return Page();
                }

                Grupo.Materia = null;

                _context.Grupos.Add(Grupo);
                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            
        }
    }
}