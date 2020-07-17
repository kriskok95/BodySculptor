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

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var foodForEditDto = await this.nutritionService
                .GetFood(id);
            var foodCategories = await this.nutritionService
                .GetFoodCategories();

            ViewData["foodDto"] = foodForEditDto.Content;
            ViewData["foodCategories"] = foodCategories.Content;

            return View();
        }

        [HttpPost]
        [Route("{Id}")]
        public async Task<IActionResult> Edit(UpdateFoodInputModel model)
        {
            string foodId = RouteData.Values["Id"].ToString();

            var result = await this.nutritionService
                 .EditFood(foodId, model);


            return RedirectToAction(nameof(Index));
        }
    }
}
