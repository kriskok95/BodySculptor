namespace BodySculptor.Articles.Controllers
{
    using BodySculptor.Articles.Constants;
    using BodySculptor.Articles.Models.Articles;
    using BodySculptor.Articles.Services.Interfaces;
    using BodySculptor.Common.Controllers;
    using BodySculptor.Common.Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using System.Threading.Tasks;

    public class ArticlesController : ApiController
    {
        private readonly IArticlesService articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var articles = await this.articlesService
                .GetAllArticlesAsync();

            return Ok(articles);
        }

        [HttpGet]
        [Route("{articleId}")]
        public async Task<ActionResult> GetById(int articleId)
        {
            var isArticleExists = await this.articlesService
                .IsArticleExists(articleId);

            if (!isArticleExists)
            {
                return BadRequest(string.Format(ArticlesConstants.UnexistingArticle, articleId));
            }

            var article = await this.articlesService
                .GetArticleByIdAsync(articleId);

            return Ok(article);
        }

        [HttpPost]
        [AuthorizeAdministrator]
        public async Task<ActionResult> Create(CreateArticleInputModel model)
        {
            var articleDto = await this.articlesService
                .CreateArticleAsync(model);

            return Ok(articleDto);
        }

        //TODO: Implement Edit Article
        //public async Task<ActionResult> Edit()
        //{

        //}

        [HttpDelete]
        [Route("{articleId}")]
        [AuthorizeAdministrator]
        public async Task<ActionResult> Delete(int articleId)
        {
            var isArticleExists = await this.articlesService
                .IsArticleExists(articleId);

            if (!isArticleExists)
            {
                return BadRequest(string.Format(ArticlesConstants.UnexistingArticle, articleId));
            }

            await this.articlesService
                .DeleteArticleAsync(articleId);

            return NoContent();
        }
    }
}
