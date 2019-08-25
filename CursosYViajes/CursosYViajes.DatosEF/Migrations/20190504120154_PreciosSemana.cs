using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursosYViajes.DatosEF.Migrations
{
    public partial class PreciosSemana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrecioPorCursoPorSemana",
                columns: table => new
                {
                    IdPrecioPorCursoPorSemana = table.Column<Guid>(nullable: false),
                    IdCurso = table.Column<Guid>(nullable: false),
                    NumSemana = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioPorCursoPorSemana", x => x.IdPrecioPorCursoPorSemana);
                    table.ForeignKey(
                        name: "FK_PrecioPorCursoPorSemana_Cursos_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoHospedaje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHospedaje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrecioHospedajePorCursoPorSemanas",
                columns: table => new
                {
                    IdPrecioHospedajePorCursoPorSemana = table.Column<Guid>(nullable: false),
                    IdCurso = table.Column<Guid>(nullable: false),
                    IdTipoDeHospedaje = table.Column<int>(nullable: false),
                    NumSemana = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioHospedajePorCursoPorSemanas", x => x.IdPrecioHospedajePorCursoPorSemana);
                    table.ForeignKey(
                        name: "FK_PrecioHospedajePorCursoPorSemanas_Cursos_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrecioHospedajePorCursoPorSemanas_TipoHospedaje_IdTipoDeHospedaje",
                        column: x => x.IdTipoDeHospedaje,
                        principalTable: "TipoHospedaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrecioHospedajePorCursoPorSemanas_IdCurso",
                table: "PrecioHospedajePorCursoPorSemanas",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_PrecioHospedajePorCursoPorSemanas_IdTipoDeHospedaje",
                table: "PrecioHospedajePorCursoPorSemanas",
                column: "IdTipoDeHospedaje");

            migrationBuilder.CreateIndex(
                name: "IX_PrecioPorCursoPorSemana_IdCurso",
                table: "PrecioPorCursoPorSemana",
                column: "IdCurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrecioHospedajePorCursoPorSemanas");

            migrationBuilder.DropTable(
                name: "PrecioPorCursoPorSemana");

            migrationBuilder.DropTable(
                name: "TipoHospedaje");
        }
    }
}
