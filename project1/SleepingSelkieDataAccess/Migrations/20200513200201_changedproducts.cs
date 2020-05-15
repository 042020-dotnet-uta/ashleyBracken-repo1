using Microsoft.EntityFrameworkCore.Migrations;

namespace SleepingSelkieDataAccess.Migrations
{
    public partial class changedproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Inventories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
