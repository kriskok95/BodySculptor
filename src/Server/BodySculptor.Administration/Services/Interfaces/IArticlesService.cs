namespace BodySculptor.Administration.Services.Interfaces
{
    using BodySculptor.Administration.Models.Articles;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticlesService
    {
        [Get("/api/Articles")]
        Task<ApiResponse<IEnumerable<ArticleDto>>> GetArticles();

        [Headers("Content-Type: application/json")]
        [Post("/api/Articles")]
        Task<ApiResponse<ArticleDto>> CreateArticle ([Body] CreateArticleInputModel model);

        [Delete("/api/Articles/{articleId}")]
        Task DeleteArticle(string articleId);
    }
}
