namespace BodySculptor.Administration.Controllers
{
    using BodySculptor.Administration.Services.Interfaces;
    using BodySculptor.Common.Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly IStatisticsService statisticsService;

        public HomeController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        public async Task<IActionResult> Index()
        {
            if (!this.User.IsAdministrator())
            {
                return this.RedirectToAction("Login", "Identity");
            }

            var administrationStatistics = await this.statisticsService
                .GetAdministrationStatistics();

            return View(administrationStatistics.Content);
        }
    }
}
