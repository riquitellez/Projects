using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallCenterBO.Data.Migrations
{
    public partial class Niveles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Topic_IdTopic",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicSemanaTopics_SemanaTopics_IdSemanaTopics",
                table: "TopicSemanaTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicSemanaTopics_Topic_IdTopic",
                table: "TopicSemanaTopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TopicSemanaTopics",
                table: "TopicSemanaTopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topic",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SemanaTopics",
                table: "SemanaTopics");

            migrationBuilder.RenameTable(
                name: "TopicSemanaTopics",
                newName: "TopicsSemanasTopics");

            migrationBuilder.RenameTable(
                name: "Topic",
                newName: "Topics");

            migrationBuilder.RenameTable(
                name: "SemanaTopics",
                newName: "SemanasTopics");

            migrationBuilder.RenameIndex(
                name: "IX_TopicSemanaTopics_IdTopic",
                table: "TopicsSemanasTopics",
                newName: "IX_TopicsSemanasTopics_IdTopic");

            migrationBuilder.RenameIndex(
                name: "IX_TopicSemanaTopics_IdSemanaTopics",
                table: "TopicsSemanasTopics",
                newName: "IX_TopicsSemanasTopics_IdSemanaTopics");

            migrationBuilder.AddColumn<Guid>(
                name: "IdNivel",
                table: "Alumnos",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopicsSemanasTopics",
                table: "TopicsSemanasTopics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SemanasTopics",
                table: "SemanasTopics",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Niveles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_IdNivel",
                table: "Alumnos",
                column: "IdNivel");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Niveles_IdNivel",
                table: "Alumnos",
                column: "IdNivel",
                principalTable: "Niveles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Topics_IdTopic",
                table: "Clases",
                column: "IdTopic",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicsSemanasTopics_SemanasTopics_IdSemanaTopics",
                table: "TopicsSemanasTopics",
                column: "IdSemanaTopics",
                principalTable: "SemanasTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicsSemanasTopics_Topics_IdTopic",
                table: "TopicsSemanasTopics",
                column: "IdTopic",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Niveles_IdNivel",
                table: "Alumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Topics_IdTopic",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicsSemanasTopics_SemanasTopics_IdSemanaTopics",
                table: "TopicsSemanasTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicsSemanasTopics_Topics_IdTopic",
                table: "TopicsSemanasTopics");

            migrationBuilder.DropTable(
                name: "Niveles");

            migrationBuilder.DropIndex(
                name: "IX_Alumnos_IdNivel",
                table: "Alumnos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TopicsSemanasTopics",
                table: "TopicsSemanasTopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SemanasTopics",
                table: "SemanasTopics");

            migrationBuilder.DropColumn(
                name: "IdNivel",
                table: "Alumnos");

            migrationBuilder.RenameTable(
                name: "TopicsSemanasTopics",
                newName: "TopicSemanaTopics");

            migrationBuilder.RenameTable(
                name: "Topics",
                newName: "Topic");

            migrationBuilder.RenameTable(
                name: "SemanasTopics",
                newName: "SemanaTopics");

            migrationBuilder.RenameIndex(
                name: "IX_TopicsSemanasTopics_IdTopic",
                table: "TopicSemanaTopics",
                newName: "IX_TopicSemanaTopics_IdTopic");

            migrationBuilder.RenameIndex(
                name: "IX_TopicsSemanasTopics_IdSemanaTopics",
                table: "TopicSemanaTopics",
                newName: "IX_TopicSemanaTopics_IdSemanaTopics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopicSemanaTopics",
                table: "TopicSemanaTopics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topic",
                table: "Topic",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SemanaTopics",
                table: "SemanaTopics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Topic_IdTopic",
                table: "Clases",
                column: "IdTopic",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicSemanaTopics_SemanaTopics_IdSemanaTopics",
                table: "TopicSemanaTopics",
                column: "IdSemanaTopics",
                principalTable: "SemanaTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicSemanaTopics_Topic_IdTopic",
                table: "TopicSemanaTopics",
                column: "IdTopic",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
