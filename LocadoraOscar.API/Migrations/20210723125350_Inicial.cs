using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraOscar.API.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPFDoCliente = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    DataDaLocacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    LocacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmes_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filmes_Locacoes_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "Locacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmesLocacoes",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    LocacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmesLocacoes", x => new { x.FilmeId, x.LocacaoId });
                    table.ForeignKey(
                        name: "FK_FilmesLocacoes_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmesLocacoes_Locacoes_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "Locacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Ativo", "DataDeCriacao", "Nome" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 7, 23, 9, 53, 48, 799, DateTimeKind.Local).AddTicks(1179), "Ação e Aventura" },
                    { 2, true, new DateTime(2021, 7, 23, 9, 53, 48, 799, DateTimeKind.Local).AddTicks(3728), "Terror" },
                    { 3, true, new DateTime(2021, 7, 23, 9, 53, 48, 799, DateTimeKind.Local).AddTicks(3744), "Ficção Científica" },
                    { 4, true, new DateTime(2021, 7, 23, 9, 53, 48, 799, DateTimeKind.Local).AddTicks(3747), "Comédia" }
                });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Ativo", "DataDeCriacao", "GeneroId", "LocacaoId", "Nome" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 7, 23, 9, 53, 48, 793, DateTimeKind.Local).AddTicks(8196), 1, null, "O Poderoso Chefão" },
                    { 2, true, new DateTime(2021, 7, 23, 9, 53, 48, 796, DateTimeKind.Local).AddTicks(3918), 1, null, "O Rei Leão" },
                    { 5, true, new DateTime(2021, 7, 23, 9, 53, 48, 796, DateTimeKind.Local).AddTicks(3966), 2, null, "O Exorcista" },
                    { 3, true, new DateTime(2021, 7, 23, 9, 53, 48, 796, DateTimeKind.Local).AddTicks(3958), 3, null, "Star Wars" },
                    { 4, true, new DateTime(2021, 7, 23, 9, 53, 48, 796, DateTimeKind.Local).AddTicks(3962), 4, null, "Intocáveis" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_GeneroId",
                table: "Filmes",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_LocacaoId",
                table: "Filmes",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmesLocacoes_LocacaoId",
                table: "FilmesLocacoes",
                column: "LocacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmesLocacoes");

            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Locacoes");
        }
    }
}
