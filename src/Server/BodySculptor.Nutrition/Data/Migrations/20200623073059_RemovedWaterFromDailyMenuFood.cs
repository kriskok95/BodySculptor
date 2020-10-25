using Microsoft.EntityFrameworkCore.Migrations;

namespace BodySculptor.Nutrition.Migrations
{
    public partial class RemovedWaterFromDailyMenuFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Water",
                table: "DailyMenuFood");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Water",
                table: "DailyMenuFood",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
