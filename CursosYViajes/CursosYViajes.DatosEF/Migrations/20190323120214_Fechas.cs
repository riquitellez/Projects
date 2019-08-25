using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursosYViajes.DatosEF.Migrations
{
    public partial class Fechas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeAlta",
                table: "Alumnos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeBaja",
                table: "Alumnos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaDeAlta",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "FechaDeBaja",
                table: "Alumnos");
        }
    }
}
