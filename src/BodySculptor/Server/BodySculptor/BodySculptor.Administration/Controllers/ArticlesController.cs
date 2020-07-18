namespace BodySculptor.Administration.Controllers
{
    using BodySculptor.Administration.Models.Articles;
    using BodySculptor.Administration.Services.Interfaces;
    using BodySculptor.Common.Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [AuthorizeAdministrator]
    public class ArticlesController : AdministrationController
    {
        private readonly IArticlesService articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articles = await this.articlesService
                .GetArticles();

            return this.View(articles.Content);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleInputModel model)
        {
            var result = await this.articlesService
                .CreateArticle(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string articleId)
        {
            await this.articlesService
                .DeleteArticle(articleId);

            return RedirectToAction(nameof(Index));
        }
    }
}
