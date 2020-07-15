namespace BodySculptor.Administration.Controllers
{
    using BodySculptor.Common.Infrastructure;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (this.User.IsAdministrator())
            {
                return this.RedirectToAction(nameof(ExercisesController.Index), "Exercises");
            }

            return View();
        }
    }
}
