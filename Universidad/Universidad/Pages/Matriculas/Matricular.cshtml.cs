using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Universidad.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Universidad.Pages.Matriculas
{
    public class MatriculaModel : PageModel
    {
        private readonly UniversidadDBContext _context;
        private readonly UserManager<Usuario> _userManager;

        public MatriculaModel(UniversidadDBContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public async Task<IActionResult> OnPostRegistrar()
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

            var usuario = await _userManager.GetUserAsync(User);

            if (usuario == null)
            {
                return Unauthorized(); // Usuario no autenticado
            }

            var matricula = new Matricula
            {
                UsuarioId = usuario.Id,
                GrupoId = MatriculaVM.GrupoId,
                FechaMatricula = DateTime.Now
            };

            _context.Matriculas.Add(matricula);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Matriculas/Index");
        }

    }
}
