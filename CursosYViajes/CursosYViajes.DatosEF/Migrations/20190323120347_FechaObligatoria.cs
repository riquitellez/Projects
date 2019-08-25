using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursosYViajes.DatosEF.Migrations
{
    public partial class FechaObligatoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaDeAlta",
                table: "Alumnos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaDeAlta",
                table: "Alumnos",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
