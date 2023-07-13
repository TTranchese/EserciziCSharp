using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class Iniziale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denominazione = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titolo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ID_Autore = table.Column<int>(type: "int", nullable: false),
                    ID_Editore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libri_Autori_ID_Autore",
                        column: x => x.ID_Autore,
                        principalTable: "Autori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libri_Editori_ID_Editore",
                        column: x => x.ID_Editore,
                        principalTable: "Editori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libri_ID_Autore",
                table: "Libri",
                column: "ID_Autore");

            migrationBuilder.CreateIndex(
                name: "IX_Libri_ID_Editore",
                table: "Libri",
                column: "ID_Editore");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libri");

            migrationBuilder.DropTable(
                name: "Autori");

            migrationBuilder.DropTable(
                name: "Editori");
        }
    }
}
