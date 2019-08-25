using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallCenterBO.Data.Migrations
{
    public partial class CamposLinea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dia",
                table: "Disponibilidades");

            migrationBuilder.AddColumn<bool>(
                name: "ConIncidencia",
                table: "Lineas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "IdEmpresa",
                table: "Lineas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_IdEmpresa",
                table: "Lineas",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Lineas_EmpresasProfesor_IdEmpresa",
                table: "Lineas",
                column: "IdEmpresa",
                principalTable: "EmpresasProfesor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lineas_EmpresasProfesor_IdEmpresa",
                table: "Lineas");

            migrationBuilder.DropIndex(
                name: "IX_Lineas_IdEmpresa",
                table: "Lineas");

            migrationBuilder.DropColumn(
                name: "ConIncidencia",
                table: "Lineas");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Lineas");

            migrationBuilder.AddColumn<string>(
                name: "Dia",
                table: "Disponibilidades",
                nullable: true);
        }
    }
}
