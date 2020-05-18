using Microsoft.EntityFrameworkCore.Migrations;

namespace SleepingSelkieDataAccess.Migrations
{
    public partial class changedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClericsTalismanBought",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MagicWandsBought",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClericsTalismanBought",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MagicWandsBought",
                table: "Orders");
        }
    }
}
