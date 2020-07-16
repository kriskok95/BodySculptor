namespace BodySculptor.Administration.Controllers
{
    using BodySculptor.Administration.Models.Foods;
    using BodySculptor.Administration.Services.Interfaces;
    using BodySculptor.Common.Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [AuthorizeAdministrator]
    public class NutritionController : AdministrationController
    {
        private readonly INutritionService nutritionService;

        public NutritionController(INutritionService nutritionService)
        {
            this.nutritionService = nutritionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var foods = await this.nutritionService
                .GetFoods();

            return View(foods.Content);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var foodCategories = await this.nutritionService
                .GetFoodCategories();

            ViewData["foodCategories"] = foodCategories.Content;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFoodInputModel model)
        {
            var result = await this.nutritionService
                .CreateFood(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
