using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BodySculptor.Nutrition.Migrations
{
    public partial class AddedDailyMenuFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_DailyMenus_DailyMenuId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_DailyMenuId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "DailyMenuId",
                table: "Foods");

            migrationBuilder.CreateTable(
                name: "DailyMenuFood",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    FoodId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    DailyMenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMenuFood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyMenuFood_DailyMenus_DailyMenuId",
                        column: x => x.DailyMenuId,
                        principalTable: "DailyMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyMenuFood_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyMenuFood_DailyMenuId",
                table: "DailyMenuFood",
                column: "DailyMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyMenuFood_FoodId",
                table: "DailyMenuFood",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMenuFood");

            migrationBuilder.AddColumn<int>(
                name: "DailyMenuId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_DailyMenuId",
                table: "Foods",
                column: "DailyMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_DailyMenus_DailyMenuId",
                table: "Foods",
                column: "DailyMenuId",
                principalTable: "DailyMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
