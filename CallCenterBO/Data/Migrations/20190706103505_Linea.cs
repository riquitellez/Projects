using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallCenterBO.Data.Migrations
{
    public partial class Linea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Profesores",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "HoraInicio",
                table: "Clases",
                newName: "FechaHoraInicio");

            migrationBuilder.RenameColumn(
                name: "HoraFin",
                table: "Clases",
                newName: "FechaHoraFin");

            migrationBuilder.AddColumn<Guid>(
                name: "IdLinea",
                table: "Clases",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IdLinea",
                table: "Clases",
                column: "IdLinea");

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Lineas_IdLinea",
                table: "Clases",
                column: "IdLinea",
                principalTable: "Lineas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Lineas_IdLinea",
                table: "Clases");

            migrationBuilder.DropIndex(
                name: "IX_Clases_IdLinea",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "IdLinea",
                table: "Clases");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Profesores",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FechaHoraInicio",
                table: "Clases",
                newName: "HoraInicio");

            migrationBuilder.RenameColumn(
                name: "FechaHoraFin",
                table: "Clases",
                newName: "HoraFin");
        }
    }
}
