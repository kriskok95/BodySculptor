using Microsoft.EntityFrameworkCore.Migrations;

namespace BodySculptor.Exercises.Migrations
{
    public partial class SetDeleteBihaviorNoActionOnMuscleGroupExercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MuscleGroupExercises_Exercises_ExerciseId",
                table: "MuscleGroupExercises");

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleGroupExercises_Exercises_ExerciseId",
                table: "MuscleGroupExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MuscleGroupExercises_Exercises_ExerciseId",
                table: "MuscleGroupExercises");

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleGroupExercises_Exercises_ExerciseId",
                table: "MuscleGroupExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
