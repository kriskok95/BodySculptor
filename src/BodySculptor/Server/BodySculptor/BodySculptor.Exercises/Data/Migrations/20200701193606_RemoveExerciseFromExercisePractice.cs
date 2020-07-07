using Microsoft.EntityFrameworkCore.Migrations;

namespace BodySculptor.Exercises.Migrations
{
    public partial class RemoveExerciseFromExercisePractice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePractice_Exercises_ExerciseId",
                table: "ExercisePractice");

            migrationBuilder.DropIndex(
                name: "IX_ExercisePractice_ExerciseId",
                table: "ExercisePractice");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "ExercisePractice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "ExercisePractice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePractice_ExerciseId",
                table: "ExercisePractice",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePractice_Exercises_ExerciseId",
                table: "ExercisePractice",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
