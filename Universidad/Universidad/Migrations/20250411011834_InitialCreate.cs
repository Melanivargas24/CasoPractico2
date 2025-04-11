using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universidad.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id_Materia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Materia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id_Materia);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id_Persona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Estado = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id_Persona);
                });

            migrationBuilder.CreateTable(
                name: "Educadores",
                columns: table => new
                {
                    Id_Educador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Persona = table.Column<int>(type: "int", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PersonaId_Persona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educadores", x => x.Id_Educador);
                    table.ForeignKey(
                        name: "FK_Educadores_Personas_PersonaId_Persona",
                        column: x => x.PersonaId_Persona,
                        principalTable: "Personas",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducadorXMaterias",
                columns: table => new
                {
                    Id_Educador = table.Column<int>(type: "int", nullable: false),
                    Id_Materia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducadorXMaterias", x => new { x.Id_Educador, x.Id_Materia });
                    table.ForeignKey(
                        name: "FK_EducadorXMaterias_Educadores_Id_Educador",
                        column: x => x.Id_Educador,
                        principalTable: "Educadores",
                        principalColumn: "Id_Educador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducadorXMaterias_Materias_Id_Materia",
                        column: x => x.Id_Materia,
                        principalTable: "Materias",
                        principalColumn: "Id_Materia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id_Grupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Grupo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id_Educador = table.Column<int>(type: "int", nullable: false),
                    EducadorId_Educador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id_Grupo);
                    table.ForeignKey(
                        name: "FK_Grupos_Educadores_EducadorId_Educador",
                        column: x => x.EducadorId_Educador,
                        principalTable: "Educadores",
                        principalColumn: "Id_Educador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id_Estudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Persona = table.Column<int>(type: "int", nullable: false),
                    Id_Grupo = table.Column<int>(type: "int", nullable: true),
                    PersonaId_Persona = table.Column<int>(type: "int", nullable: false),
                    GrupoId_Grupo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id_Estudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Grupos_GrupoId_Grupo",
                        column: x => x.GrupoId_Grupo,
                        principalTable: "Grupos",
                        principalColumn: "Id_Grupo");
                    table.ForeignKey(
                        name: "FK_Estudiantes_Personas_PersonaId_Persona",
                        column: x => x.PersonaId_Persona,
                        principalTable: "Personas",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id_Nota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Estudiante = table.Column<int>(type: "int", nullable: false),
                    Id_Materia = table.Column<int>(type: "int", nullable: false),
                    Calificacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstudianteId_Estudiante = table.Column<int>(type: "int", nullable: false),
                    MateriaId_Materia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id_Nota);
                    table.ForeignKey(
                        name: "FK_Notas_Estudiantes_EstudianteId_Estudiante",
                        column: x => x.EstudianteId_Estudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "Id_Estudiante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_Materias_MateriaId_Materia",
                        column: x => x.MateriaId_Materia,
                        principalTable: "Materias",
                        principalColumn: "Id_Materia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educadores_PersonaId_Persona",
                table: "Educadores",
                column: "PersonaId_Persona");

            migrationBuilder.CreateIndex(
                name: "IX_EducadorXMaterias_Id_Materia",
                table: "EducadorXMaterias",
                column: "Id_Materia");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_GrupoId_Grupo",
                table: "Estudiantes",
                column: "GrupoId_Grupo");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_PersonaId_Persona",
                table: "Estudiantes",
                column: "PersonaId_Persona");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_EducadorId_Educador",
                table: "Grupos",
                column: "EducadorId_Educador");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_EstudianteId_Estudiante",
                table: "Notas",
                column: "EstudianteId_Estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_MateriaId_Materia",
                table: "Notas",
                column: "MateriaId_Materia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducadorXMaterias");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Educadores");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
