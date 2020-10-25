namespace BodySculptor.Exercises.Controllers
{
    using BodySculptor.Common.Controllers;
    using BodySculptor.Exercises.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MuscleGroupsController : ApiController
    {
        private readonly IMuscleGroupsService muscleGroupsService;

        public MuscleGroupsController(IMuscleGroupsService muscleGroupsService)
        {
            this.muscleGroupsService = muscleGroupsService;
        }

        public async Task<ActionResult> GetAll()
        {
            var muscleGroups = await this.muscleGroupsService
                .GetAllMuscleGroups();

            return Ok(muscleGroups);
        }
    }
}
