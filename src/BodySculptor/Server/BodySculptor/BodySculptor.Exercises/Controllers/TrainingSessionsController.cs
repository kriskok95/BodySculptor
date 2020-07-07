namespace BodySculptor.Exercises.Controllers
{
    using BodySculptor.Common.Controllers;
    using BodySculptor.Common.Services.Intefraces;
    using BodySculptor.Exercises.Models.TrainingSessions;
    using BodySculptor.Exercises.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class TrainingSessionsController : ApiController
    {
        private readonly ITrainingSessionsService trainingSessionsService;
        private readonly ICurrentUserService currentUserService;

        public TrainingSessionsController(ITrainingSessionsService trainingSessionsService, ICurrentUserService currentUserService)
        {
            this.trainingSessionsService = trainingSessionsService;
            this.currentUserService = currentUserService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(TrainingSessionInputModel input)
        {
            var userId = this.currentUserService
                .UserId;

            var result = await this.trainingSessionsService
                .CreateTrainingSessionAsync(userId, input);


            return Ok(result);
        }
    }
}
