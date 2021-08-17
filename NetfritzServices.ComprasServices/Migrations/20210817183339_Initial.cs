using Microsoft.EntityFrameworkCore.Migrations;

namespace NetfritzServices.ComprasServices.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacaos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CompraId = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Nota = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ClienteId = table.Column<string>(type: "text", nullable: false),
                    FitaId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacaos");

            migrationBuilder.DropTable(
                name: "Compras");
        }
    }
}
