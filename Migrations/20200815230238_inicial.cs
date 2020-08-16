using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testelinux.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeTarefa = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    DataCadastrada = table.Column<DateTime>(nullable: false),
                    DataConcluida = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
