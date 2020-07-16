namespace BodySculptor.Administration.Controllers
{
    using BodySculptor.Administration.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class NutritionController : AdministrationController
    {
        private readonly INutritionService nutritionService;

        public NutritionController(INutritionService nutritionService)
        {
            this.nutritionService = nutritionService;
        }

        public async Task<IActionResult> Index()
        {
            //var foods = await this.nutritionService.
            return null;
        }
    }
}
