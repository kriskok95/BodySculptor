﻿namespace BodySculptor.Exercises.Controllers
{
    using BodySculptor.Common.Controllers;
    using BodySculptor.Common.Infrastructure;
    using BodySculptor.Exercises.Constants;
    using BodySculptor.Exercises.Models.Exercises;
    using BodySculptor.Exercises.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ExercisesController : ApiController
    {
        private readonly IExercisesService exercisesService;
        private readonly IMuscleGroupsService muscleGroupsService;

        public ExercisesController(IExercisesService exercisesService, IMuscleGroupsService muscleGroupsService)
        {
            this.exercisesService = exercisesService;
            this.muscleGroupsService = muscleGroupsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await this.exercisesService
                .GetAllExercisesAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("{GetByMuscleGroup}/{muscleGroupId}")]
        public async Task<ActionResult> GetByMuscleGroup(int muscleGroupId)
        {
            var isMuscleGroupExists = await this.muscleGroupsService
                .IsExistsById(muscleGroupId);

            if (!isMuscleGroupExists)
            {
                return NotFound(string.Format(MuscleGroupsConstants.UnexistingMuscleGroupById, muscleGroupId));
            }

            var result = await this.exercisesService
                .GetAllByMuscleGroupAsync(muscleGroupId);

            return Ok(result);
        }

        [HttpGet]
        [Route("{exerciseId}", Name = "GetById")]
        public async Task<ActionResult> GetById([FromRoute] int exerciseId)
        {
            var result = await this.exercisesService
                .GetExerciseByIdAsync(exerciseId);

            if (result == null)
            {
                return NotFound(string.Format(ExercisesConstants.UnexistingExercise, exerciseId));
            }

            return Ok(result);
        }

        [HttpPost]
        [AuthorizeAdministrator]
        public async Task<ActionResult> Create(ExerciseInputModel input)
        {
            var isExerciseExists = await this.exercisesService
                .IsExerciseExistsByName(input.Name);

            if (isExerciseExists)
            {
                return BadRequest(ExercisesConstants.ExistingExercise);
            }

            var result = await this.exercisesService
                .CreateExerciseAsync(input);

            return CreatedAtRoute("GetById",
                new { exerciseId = result.Id },
                result);
        }

        [HttpPut]
        [Route("{exerciseId}")]
        [AuthorizeAdministrator]
        public async Task<ActionResult> Edit(int exerciseId, ExerciseEditModel input)
        {
            var isExerciseExists = await this.exercisesService
                .IsExistsByIdAsync(exerciseId);

            if (!isExerciseExists)
            {
                return BadRequest(string.Format(ExercisesConstants.UnexistingExercise, exerciseId));
            }

            var result = await this.exercisesService
                .EditExerciseAsync(exerciseId, input);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{exerciseId}")]
        public async Task<ActionResult> Delete (int exerciseId)
        {
            var isExerciseExists = await this.exercisesService
                .IsExistsByIdAsync(exerciseId);

            if (!isExerciseExists)
            {
                return NotFound(string.Format(ExercisesConstants.UnexistingExercise, exerciseId));
            }

            await this.exercisesService
                .DeleteExerciseByIdAsync(exerciseId);

            return NoContent();
        }
    }
}
