namespace BodySculptor.Administration.Controllers
{
    using BodySculptor.Administration.Models.Exercises;
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

            return this.View(exercises.Content);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var muscleGroups = await this.exercisesService
                .GetMuscleGroups();

            ViewData["muscleGroups"] = muscleGroups.Content;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseInputModel model)
        {
            var result = await this.exercisesService
                .CreateExercise(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
