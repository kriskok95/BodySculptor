namespace BodySculptor.Articles.Services
{
    using BodySculptor.Articles.Data;
    using BodySculptor.Articles.Data.Entities;
    using BodySculptor.Articles.Models.Articles;
    using BodySculptor.Articles.Services.Interfaces;
    using BodySculptor.Common.Services.Intefraces;
    using BodySculptor.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ArticlesService : IArticlesService
    {
        private readonly ArticlesDbContext context;
        private readonly ICurrentUserService currentUserService;

        public ArticlesService(ArticlesDbContext context, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.currentUserService = currentUserService;
        }

        public async Task<IEnumerable<ArticleDto>> GetAllArticlesAsync()
        {
            var articles = await this.context
                .Articles
                .To<ArticleDto>()
                .ToListAsync();

            return articles;
        }

        public async Task<ArticleDto> GetArticleByIdAsync(int articleId)
        {
            var articleFromDb = await this.context
                .Articles
                .FirstOrDefaultAsync(x => x.Id == articleId);

            var articleToReturn = articleFromDb
                .MapTo<ArticleDto>();

            return articleToReturn;
        }

        public async Task<ArticleDto> CreateArticleAsync(CreateArticleInputModel model)
        {
            var currentUserId = this.currentUserService
                .UserId;

            var articleForDb = model
                .MapTo<Article>();

            articleForDb.AuthorId = currentUserId;

            await this.context
                .Articles
                .AddAsync(articleForDb);

            await this.context.SaveChangesAsync();

            var articleToReturn = articleForDb
                .MapTo<ArticleDto>();

            return articleToReturn;
        }

        public async Task DeleteArticleAsync(int articleId)
        {
            var articleToRemove = new Article { Id = articleId };

            this.context
                .Articles
                .Remove(articleToRemove);

            await this.context
                .SaveChangesAsync();
        }

        public async Task<bool> IsArticleExists(int articleId)
        {
            var isArticleExists = await this.context
                .Articles
                .AnyAsync(x => x.Id == articleId);

            return isArticleExists;
        }
    }
}
