﻿namespace BodySculptor.API.Data.Models
{
    public class ExerciseExercisePractices
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public int ExercisePracticeId { get; set; }
        public ExercisePractice ExercisePractice { get; set; }
    }
}
