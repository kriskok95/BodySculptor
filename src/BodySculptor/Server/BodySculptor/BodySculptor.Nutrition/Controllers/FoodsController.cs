namespace BodySculptor.Nutrition.Controllers
{
    using BodySculptor.Common.Controllers;
    using BodySculptor.Nutrition.Models;
    using BodySculptor.Nutrition.Services.Interfaces;
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

            var foodDto = await this.foodsService
                .GetFoodAsync(foodId);

            return Ok(foodDto);
        }

        [HttpPost]
        public async Task<ActionResult<FoodDto>> CreateFood(FoodForCreationDto food)
        {
            var isFoodCategoryExists = await this.foodsService
                .IsFoodCategoryExistsAsync(food.FoodCategoryId);

            if (!isFoodCategoryExists)
            {
                return NotFound("Category with the given id doesn't exists");
            }

            var isFoodExists = await this.foodsService
                .IsFoodExistsAsync(food.Name);

            if (isFoodExists)
            {
                return BadRequest("Food with the given name already exists");
            }

            var foodToReturn = await this.foodsService
                .CreateFoodAsync(food);

            return CreatedAtRoute("GetFood",
                new { foodId = foodToReturn.Id },
                foodToReturn);
        }

        [HttpPut("{foodId}")]
        public async Task<ActionResult> EditFood(int foodId, FoodForUpdateDto food)
        {
            var isFoodExists = await this.foodsService
                .IsFoodExistsAsync(foodId);

            if (!isFoodExists)
            {
                return NotFound("Food with the given id doesn't exists");
            }

            var isFoodCategoryExists = await this.foodsService
                .IsFoodCategoryExistsAsync(food.FoodCategoryId);

            if (!isFoodCategoryExists)
            {
                return NotFound("Category with the given id doesn't exists");
            }

            var foodToReturn = await this.foodsService
                .EditFoodAsync(foodId, food);

            return CreatedAtRoute("GetFood",
                new { foodId },
                foodToReturn);
        }


        [HttpDelete("{FoodId}")]
        public async Task<ActionResult> DeleteFood(int foodId)
        {
            var isFoodExists = await this.foodsService
                .IsFoodExistsAsync(foodId);

            if (!isFoodExists)
            {
                return NotFound("Food with the given ID doesn't exists.");
            }

            await this.foodsService
                .DeleteFood(foodId);

            return NoContent();
        }
    }
}
