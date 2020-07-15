namespace BodySculptor.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ExercisesController : AdministrationController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
