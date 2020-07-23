namespace BodySculptor.Gateway.Services.Interfaces
{
    using BodySculptor.Gateway.Models.Articles;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticlesService
    {
        [Get("/api/Articles")]
        Task<ApiResponse<IEnumerable<ArticleDto>>> GetArticles();
    }
}
