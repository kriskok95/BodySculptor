using Microsoft.EntityFrameworkCore.Migrations;

namespace BodySculptor.Statistics.Migrations
{
    public partial class TotalArticlesColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalArticles",
                table: "ClientStatistics",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalArticles",
                table: "ClientStatistics");
        }
    }
}
