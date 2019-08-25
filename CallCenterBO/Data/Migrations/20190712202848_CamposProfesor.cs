using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallCenterBO.Data.Migrations
{
    public partial class CamposProfesor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeAlta",
                table: "Profesores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeBaja",
                table: "Profesores",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Lineas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AusenciaTemporal",
                table: "Disponibilidades",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaDeAlta",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "FechaDeBaja",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Lineas");

            migrationBuilder.DropColumn(
                name: "AusenciaTemporal",
                table: "Disponibilidades");
        }
    }
}
