using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallCenterBO.Data.Migrations
{
    public partial class Alumnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duraciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duraciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    IdEmpresa = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "EmpresasProfesor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasProfesor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lineas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Numero = table.Column<string>(nullable: true),
                    FechaDeAlta = table.Column<DateTime>(nullable: false),
                    FechaDeBaja = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SemanaTopics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Anho = table.Column<int>(nullable: false),
                    NumSemana = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemanaTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeCancelacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeCancelacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeIncidencia",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeIncidencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Codigo = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    IdEmpresaProfesor = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesores_EmpresasProfesor_IdEmpresaProfesor",
                        column: x => x.IdEmpresaProfesor,
                        principalTable: "EmpresasProfesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    IdAlumno = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IdEmpresa = table.Column<Guid>(nullable: true),
                    Timetable = table.Column<string>(nullable: true),
                    FechaDeAlta = table.Column<DateTime>(nullable: false),
                    FechaDeBaja = table.Column<DateTime>(nullable: true),
                    IdPlan = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.IdAlumno);
                    table.ForeignKey(
                        name: "FK_Alumnos_Empresas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alumnos_Planes_IdPlan",
                        column: x => x.IdPlan,
                        principalTable: "Planes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CancelacionesDisponibilidad",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTipoDeCancelacion = table.Column<Guid>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaDeInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelacionesDisponibilidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CancelacionesDisponibilidad_TiposDeCancelacion_IdTipoDeCancelacion",
                        column: x => x.IdTipoDeCancelacion,
                        principalTable: "TiposDeCancelacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicSemanaTopics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTopic = table.Column<Guid>(nullable: false),
                    IdSemanaTopics = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicSemanaTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicSemanaTopics_SemanaTopics_IdSemanaTopics",
                        column: x => x.IdSemanaTopics,
                        principalTable: "SemanaTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicSemanaTopics_Topic_IdTopic",
                        column: x => x.IdTopic,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdAlumno = table.Column<Guid>(nullable: false),
                    IdProfesor = table.Column<Guid>(nullable: false),
                    HoraInicio = table.Column<DateTime>(nullable: false),
                    HoraFin = table.Column<DateTime>(nullable: false),
                    IdTipoDeIncidencia = table.Column<Guid>(nullable: true),
                    IdDuracion = table.Column<Guid>(nullable: false),
                    IdTopic = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clases_Alumnos_IdAlumno",
                        column: x => x.IdAlumno,
                        principalTable: "Alumnos",
                        principalColumn: "IdAlumno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clases_Duraciones_IdDuracion",
                        column: x => x.IdDuracion,
                        principalTable: "Duraciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clases_Profesores_IdProfesor",
                        column: x => x.IdProfesor,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clases_TiposDeIncidencia_IdTipoDeIncidencia",
                        column: x => x.IdTipoDeIncidencia,
                        principalTable: "TiposDeIncidencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clases_Topic_IdTopic",
                        column: x => x.IdTopic,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disponibilidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Dia = table.Column<string>(nullable: true),
                    HoraInicio = table.Column<DateTime>(nullable: false),
                    HoraFin = table.Column<DateTime>(nullable: false),
                    IdLinea = table.Column<Guid>(nullable: true),
                    IdCancelacion = table.Column<Guid>(nullable: true),
                    IdProfesor = table.Column<Guid>(nullable: false),
                    CancelacionDisponibilidadId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disponibilidades_CancelacionesDisponibilidad_CancelacionDisponibilidadId",
                        column: x => x.CancelacionDisponibilidadId,
                        principalTable: "CancelacionesDisponibilidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disponibilidades_Lineas_IdLinea",
                        column: x => x.IdLinea,
                        principalTable: "Lineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disponibilidades_Profesores_IdProfesor",
                        column: x => x.IdProfesor,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_IdEmpresa",
                table: "Alumnos",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_IdPlan",
                table: "Alumnos",
                column: "IdPlan");

            migrationBuilder.CreateIndex(
                name: "IX_CancelacionesDisponibilidad_IdTipoDeCancelacion",
                table: "CancelacionesDisponibilidad",
                column: "IdTipoDeCancelacion");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IdAlumno",
                table: "Clases",
                column: "IdAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IdDuracion",
                table: "Clases",
                column: "IdDuracion");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IdProfesor",
                table: "Clases",
                column: "IdProfesor");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IdTipoDeIncidencia",
                table: "Clases",
                column: "IdTipoDeIncidencia");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IdTopic",
                table: "Clases",
                column: "IdTopic");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidades_CancelacionDisponibilidadId",
                table: "Disponibilidades",
                column: "CancelacionDisponibilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidades_IdLinea",
                table: "Disponibilidades",
                column: "IdLinea");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidades_IdProfesor",
                table: "Disponibilidades",
                column: "IdProfesor");

            migrationBuilder.CreateIndex(
                name: "IX_Profesores_IdEmpresaProfesor",
                table: "Profesores",
                column: "IdEmpresaProfesor");

            migrationBuilder.CreateIndex(
                name: "IX_TopicSemanaTopics_IdSemanaTopics",
                table: "TopicSemanaTopics",
                column: "IdSemanaTopics");

            migrationBuilder.CreateIndex(
                name: "IX_TopicSemanaTopics_IdTopic",
                table: "TopicSemanaTopics",
                column: "IdTopic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "Disponibilidades");

            migrationBuilder.DropTable(
                name: "TopicSemanaTopics");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Duraciones");

            migrationBuilder.DropTable(
                name: "TiposDeIncidencia");

            migrationBuilder.DropTable(
                name: "CancelacionesDisponibilidad");

            migrationBuilder.DropTable(
                name: "Lineas");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "SemanaTopics");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "TiposDeCancelacion");

            migrationBuilder.DropTable(
                name: "EmpresasProfesor");
        }
    }
}
