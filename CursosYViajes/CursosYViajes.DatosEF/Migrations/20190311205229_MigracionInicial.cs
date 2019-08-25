using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursosYViajes.DatosEF.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    IdAlumno = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.IdAlumno);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    IdPais = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.IdPais);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    IdCurso = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    IdPais = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IdCurso);
                    table.ForeignKey(
                        name: "FK_Cursos_Paises_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Paises",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursosPorAlumno",
                columns: table => new
                {
                    IdCursoPorAlumno = table.Column<Guid>(nullable: false),
                    IdAlumno = table.Column<Guid>(nullable: false),
                    IdCurso = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursosPorAlumno", x => x.IdCursoPorAlumno);
                    table.ForeignKey(
                        name: "FK_CursosPorAlumno_Alumnos_IdAlumno",
                        column: x => x.IdAlumno,
                        principalTable: "Alumnos",
                        principalColumn: "IdAlumno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursosPorAlumno_Cursos_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_IdPais",
                table: "Cursos",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_CursosPorAlumno_IdAlumno",
                table: "CursosPorAlumno",
                column: "IdAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_CursosPorAlumno_IdCurso",
                table: "CursosPorAlumno",
                column: "IdCurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursosPorAlumno");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
