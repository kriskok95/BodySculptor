namespace BodySculptor.Nutrition.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangedUserIdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyMenus_Users_UserId",
                table: "DailyMenus");

            migrationBuilder.DropIndex(
                name: "IX_DailyMenus_UserId",
                table: "DailyMenus");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "DailyMenus",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "DailyMenus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DailyMenuFood",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Water",
                table: "DailyMenuFood",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_DailyMenus_UserId1",
                table: "DailyMenus",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyMenus_Users_UserId1",
                table: "DailyMenus",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyMenus_Users_UserId1",
                table: "DailyMenus");

            migrationBuilder.DropIndex(
                name: "IX_DailyMenus_UserId1",
                table: "DailyMenus");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "DailyMenus");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DailyMenuFood");

            migrationBuilder.DropColumn(
                name: "Water",
                table: "DailyMenuFood");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DailyMenus",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyMenus_UserId",
                table: "DailyMenus",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyMenus_Users_UserId",
                table: "DailyMenus",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
