using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Universidad.Models;

namespace Universidad.Pages.Matriculas
{
    public class MatriculaModel : PageModel
    {
        private readonly UniversidadDBContext _context;

        public MatriculaModel(UniversidadDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MatriculaViewModel MatriculaVM { get; set; } = new();

        public void OnGet()
        {
            MatriculaVM.Carreras = _context.Carreras.ToList();
        }

        public IActionResult OnPostGetMaterias()
        {
            MatriculaVM.Materias = _context.MateriasCarreras
                .Where(mc => mc.CarreraId == MatriculaVM.CarreraId)
                .Select(mc => mc.Materia)
                .ToList();

            MatriculaVM.Carreras = _context.Carreras.ToList();

            return Page();
        }

        public IActionResult OnPostGetGrupos()
        {
            MatriculaVM.Grupos = _context.Grupos
                .Where(g => g.MateriaId == MatriculaVM.MateriaId)
                .ToList();

            MatriculaVM.Carreras = _context.Carreras.ToList();
            MatriculaVM.Materias = _context.MateriasCarreras
                .Where(mc => mc.CarreraId == MatriculaVM.CarreraId)
                .Select(mc => mc.Materia)
                .ToList();

            return Page();
        }

        public IActionResult OnPostRegistrar()
        {
            if (!ModelState.IsValid)
            {
                MatriculaVM.Carreras = _context.Carreras.ToList();
                MatriculaVM.Materias = _context.MateriasCarreras
                    .Where(mc => mc.CarreraId == MatriculaVM.CarreraId)
                    .Select(mc => mc.Materia)
                    .ToList();
                MatriculaVM.Grupos = _context.Grupos
                    .Where(g => g.MateriaId == MatriculaVM.MateriaId)
                    .ToList();

                return Page();
            }

            var matricula = new Matricula
            {
                UsuarioId = 1,
                GrupoId = MatriculaVM.GrupoId,
                FechaMatricula = DateTime.Now
            };

            _context.Matriculas.Add(matricula);         
            _context.SaveChanges();

            return RedirectToPage("/Matriculas/Index");
        }

    }
}
