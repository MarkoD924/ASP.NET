using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Menu.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jela", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sastojci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sastojci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SastojciJela",
                columns: table => new
                {
                    JelaId = table.Column<int>(type: "int", nullable: false),
                    SastojciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SastojciJela", x => new { x.JelaId, x.SastojciId });
                    table.ForeignKey(
                        name: "FK_SastojciJela_Jela_JelaId",
                        column: x => x.JelaId,
                        principalTable: "Jela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SastojciJela_Sastojci_JelaId",
                        column: x => x.JelaId,
                        principalTable: "Sastojci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Jela",
                columns: new[] { "Id", "Cena", "ImageUrl", "Ime" },
                values: new object[] { 1, 1500.0, "https://images.prismic.io/eataly-us/ed3fcec7-7994-426d-a5e4-a24be5a95afd_pizza-recipe-main.jpg?auto=compress,format", "Margarita" });

            migrationBuilder.InsertData(
                table: "Sastojci",
                columns: new[] { "Id", "Ime" },
                values: new object[,]
                {
                    { 1, "Paradajz sos" },
                    { 2, "Mocarela" }
                });

            migrationBuilder.InsertData(
                table: "SastojciJela",
                columns: new[] { "JelaId", "SastojciId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SastojciJela");

            migrationBuilder.DropTable(
                name: "Jela");

            migrationBuilder.DropTable(
                name: "Sastojci");
        }
    }
}
