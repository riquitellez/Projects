using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursosYViajes.DatosEF.Migrations
{
    public partial class CursosYFechas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeAlta",
                table: "CursosPorAlumno",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeBaja",
                table: "CursosPorAlumno",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeAlta",
                table: "Cursos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeBaja",
                table: "Cursos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaDeAlta",
                table: "CursosPorAlumno");

            migrationBuilder.DropColumn(
                name: "FechaDeBaja",
                table: "CursosPorAlumno");

            migrationBuilder.DropColumn(
                name: "FechaDeAlta",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "FechaDeBaja",
                table: "Cursos");
        }
    }
}
