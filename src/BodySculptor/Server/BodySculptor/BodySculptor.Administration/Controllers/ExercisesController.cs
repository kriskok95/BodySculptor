namespace BodySculptor.Administration.Controllers
{
    using BodySculptor.Administration.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ExercisesController : AdministrationController
    {
        private readonly IExercisesService exercisesService;

        public ExercisesController(IExercisesService exercisesService)
        {
            this.exercisesService = exercisesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var exercises = await this.exercisesService
                .GetExercises();

            return this.View(exercises);
        }
    }
}
