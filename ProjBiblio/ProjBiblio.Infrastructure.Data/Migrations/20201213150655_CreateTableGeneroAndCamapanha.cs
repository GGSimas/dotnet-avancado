using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjBiblio.Infrastructure.Data.Migrations
{
    public partial class CreateTableGeneroAndCamapanha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ano",
                table: "Livro",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Edicao",
                table: "Livro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Editora",
                table: "Livro",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Livro",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Paginas",
                table: "Livro",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CampanhaMarketing",
                columns: table => new
                {
                    CampanhaMarketingId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    PercentualDesconto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaMarketing", x => x.CampanhaMarketingId);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    GeneroId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "CampanhaMarketingLivro",
                columns: table => new
                {
                    CampanhaId = table.Column<int>(nullable: false),
                    LivroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaMarketingLivro", x => new { x.CampanhaId, x.LivroId });
                    table.ForeignKey(
                        name: "FK_CampanhaMarketingLivro_CampanhaMarketing_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "CampanhaMarketing",
                        principalColumn: "CampanhaMarketingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampanhaMarketingLivro_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "LivroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_GeneroId",
                table: "Livro",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaMarketingLivro_LivroId",
                table: "CampanhaMarketingLivro",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Genero_GeneroId",
                table: "Livro",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "GeneroId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Genero_GeneroId",
                table: "Livro");

            migrationBuilder.DropTable(
                name: "CampanhaMarketingLivro");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "CampanhaMarketing");

            migrationBuilder.DropIndex(
                name: "IX_Livro_GeneroId",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "Edicao",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "Editora",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "Paginas",
                table: "Livro");
        }
    }
}
