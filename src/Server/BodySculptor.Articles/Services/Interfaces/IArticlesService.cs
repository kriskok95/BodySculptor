namespace BodySculptor.Articles.Services.Interfaces
{
    using BodySculptor.Articles.Data.Entities;
    using BodySculptor.Articles.Models.Articles;
    using BodySculptor.Common.Services.Intefraces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticlesService : IDataService<Article>
    {
        Task<IEnumerable<ArticleDto>> GetAllArticlesAsync();

        Task<ArticleDto> GetArticleByIdAsync(int articleId);

        Task<ArticleDto> CreateArticleAsync(CreateArticleInputModel model);

        Task<bool> IsArticleExists(int articleId);

        Task DeleteArticleAsync(int articleId);
    }
}
