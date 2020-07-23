namespace BodySculptor.Statistics.Controllers
{
    using BodySculptor.Common.Controllers;
    using BodySculptor.Statistics.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ClientStatisticsController : ApiController
    {
        private readonly IClientStatisticsService clientStatisticsService;

        public ClientStatisticsController(IClientStatisticsService clientStatisticsService)
        {
            this.clientStatisticsService = clientStatisticsService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var clientStatistics = await this.clientStatisticsService
                .GetClientStatisticsAsync();

            return Ok(clientStatistics);
        }
    }
}
