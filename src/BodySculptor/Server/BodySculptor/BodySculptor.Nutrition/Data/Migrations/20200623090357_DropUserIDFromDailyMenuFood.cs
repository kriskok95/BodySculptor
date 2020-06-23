using Microsoft.EntityFrameworkCore.Migrations;

namespace BodySculptor.Nutrition.Migrations
{
    public partial class DropUserIDFromDailyMenuFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DailyMenuFood");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DailyMenuFood",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
