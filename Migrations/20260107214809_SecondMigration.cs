using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Net.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reclamacoes",
                columns: table => new
                {
                    ReclamacaoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Assunto = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NomeConsumidor = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TextoReclamacao = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    CaminhoFicheiro = table.Column<string>(type: "TEXT", nullable: true),
                    NomeOriginalFicheiro = table.Column<string>(type: "TEXT", nullable: true),
                    DataEncerramento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RespostaAdmin = table.Column<string>(type: "TEXT", nullable: true),
                    CaminhoFicheiroAdmin = table.Column<string>(type: "TEXT", nullable: true),
                    NomeOriginalFicheiroAdmin = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamacoes", x => x.ReclamacaoID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reclamacoes");
        }
    }
}
