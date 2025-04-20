using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Universidad.Models;

namespace Universidad.Pages.Cuenta
{
    public class RegistroModel : PageModel
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UniversidadDBContext _context;

        public RegistroModel(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            RoleManager<IdentityRole> roleManager,
            UniversidadDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required]
            public string Nombre { get; set; }

            [Required]
            public string Apellido { get; set; }

            [Required]
            [EmailAddress]
            public string Correo { get; set; }

            [Required]
            public string Telefono { get; set; }

            [Required]
            public string Tipo { get; set; } // Estudiante o Administrador

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Crear y guardar la persona
            var persona = new Persona
            {
                Nombre = Input.Nombre,
                Apellido = Input.Apellido,
                Correo = Input.Correo,
                Telefono = Input.Telefono,
                Tipo = Input.Tipo
            };

            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            // Crear el usuario vinculado a la persona
            var user = new Usuario
            {
                UserName = Input.Correo,
                Email = Input.Correo,
                PersonaId = persona.Id,
                Rol = Input.Tipo
            };

            var result = await _userManager.CreateAsync(user, Input.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(Input.Tipo))
                    await _roleManager.CreateAsync(new IdentityRole(Input.Tipo));

                await _userManager.AddToRoleAsync(user, Input.Tipo);

                TempData["RegistroExitoso"] = "Tu cuenta fue creada correctamente. Iniciá sesión para continuar.";
                return RedirectToPage("/Cuenta/Login");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return Page();
        }
    }
}