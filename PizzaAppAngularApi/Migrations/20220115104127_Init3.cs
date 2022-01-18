using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaAppAngularApi.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    pizzaId = table.Column<int>(type: "int", nullable: false),
                    pizzaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pizzaImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pizzaDescriptionImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");
        }
    }
}
