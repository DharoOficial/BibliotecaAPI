using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCAPIBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class AgoraVaiiii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeAutor = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeLivro = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DescLivro = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    NumeroPagina = table.Column<int>(type: "int", nullable: false),
                    IdAutor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livro_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LivroDTOsAutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeLivro = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DescLivro = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    NumeroPagina = table.Column<int>(type: "int", nullable: false),
                    IdAutor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroDTOsAutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivroDTOsAutor_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_AutorId",
                table: "Livro",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroDTOsAutor_AutorId",
                table: "LivroDTOsAutor",
                column: "AutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "LivroDTOsAutor");

            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
