namespace BodySculptor.Articles.Data.Seeding
{
    using BodySculptor.Articles.Data.Entities;
    using BodySculptor.Common.Data.Seeding;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class ArticlesSeeder : ISeeder<ArticlesDbContext>
    {
        public async Task SeedAsync(ArticlesDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Articles.AnyAsync())
            {
                return;
            }

            var user = await dbContext.Users.FirstOrDefaultAsync();

            await dbContext.Articles.AddAsync(new Article { AuthorId = user.UserId, Title = "6 Popular Ways to Do Intermittent Fasting", Content = "Intermittent fasting has recently become a health trend. It’s claimed to cause weight loss, improve metabolic health, and perhaps even extend lifespan.Several methods of this eating pattern exist.Every method can be effective,but figuring out which one works best depends on the individual.Here are 6 popular ways to do intermittent fasting. The 16/8 method. The 16/8 method involves daily fasts of 16 hours for men and 14–15 hours for women. Each day you’ll restrict your eating to an 8–10-hour eating window during which you fit in 2, 3, or more meals." , ImageUrl = "https://i0.wp.com/images-prod.healthline.com/hlcmsresource/images/topic_centers/2020-1/250481_IntermittentFasting_body_1296x728_16-8.png?w=1155&h=1528" });
        }
    }
}
