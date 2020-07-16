namespace BodySculptor.Nutrition.Controllers
{
    using BodySculptor.Common.Controllers;
    using BodySculptor.Common.Infrastructure;
    using BodySculptor.Nutrition.Constants;
    using BodySculptor.Nutrition.Models.Foods;
    using BodySculptor.Nutrition.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FoodsController : ApiController
    {
        private readonly IFoodsService foodsService;

        public FoodsController(IFoodsService foodsService)
        {
            this.foodsService = foodsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetFoods()
        {
            var foodsDto = await this.foodsService.GetFoodsAsync();

            return Ok(foodsDto);
        }

        [HttpGet("{foodId}", Name = "GetFood")]
        public async Task<ActionResult<FoodDto>> GetFood(int foodId)
        {
            var isFoodExists = await this.foodsService
                .IsFoodExistsAsync(foodId);

            if (!isFoodExists)
            {
                return NotFound();
            }

            var result = await this.foodsService
                .GetFoodAsync(foodId);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route(nameof(GetFoodCategories))]
        public async Task<ActionResult<FoodCategoryDto>> GetFoodCategories()
        {
            var foodCategories = await this.foodsService
                .GetFoodCategoriesAsync();

            return Ok(foodCategories);
        }

        [HttpPost]
        [AuthorizeAdministrator]
        public async Task<ActionResult<FoodDto>> CreateFood(FoodForCreationDto food)
        {
            var isFoodCategoryExists = await this.foodsService
                .IsFoodCategoryExistsAsync(food.FoodCategoryId);

            if (!isFoodCategoryExists)
            {
                return NotFound(string.Format(FoodCategoriesConstants.UnexistingFoodCategoryId, food.FoodCategoryId));
            }

            var isFoodExists = await this.foodsService
                .IsFoodExistsAsync(food.Name);

            if (isFoodExists)
            {
                return BadRequest(FoodsConstants.ExistingFoodByName);
            }

            var result = await this.foodsService
                .CreateFoodAsync(food);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return CreatedAtRoute("GetFood",
                new { foodId = result.Data.Id },
                result.Data);
        }

        [HttpPut("{foodId}")]
        [Authorize]
        public async Task<ActionResult> EditFood(int foodId, FoodForUpdateDto food)
        {
            var isFoodExists = await this.foodsService
                .IsFoodExistsAsync(foodId);

            if (!isFoodExists)
            {
                return NotFound(FoodsConstants.UnexistingFoodById);
            }

            var isFoodCategoryExists = await this.foodsService
                .IsFoodCategoryExistsAsync(food.FoodCategoryId);

            if (!isFoodCategoryExists)
            {
                return NotFound(FoodCategoriesConstants.UnexistingFoodCategoryId);
            }

            var result = await this.foodsService
                .EditFoodAsync(foodId, food);

            return CreatedAtRoute("GetFood",
                new { foodId },
                result.Data);
        }


        [HttpDelete("{FoodId}")]
        [Authorize]
        public async Task<ActionResult> DeleteFood(int foodId)
        {
            var isFoodExists = await this.foodsService
                .IsFoodExistsAsync(foodId);

            if (!isFoodExists)
            {
                return NotFound(string.Format(FoodsConstants.UnexistingFoodById, foodId));
            }

            await this.foodsService
                .DeleteFood(foodId);

            return NoContent();
        }
    }
}
