namespace BodySculptor.Articles.Data
{
    using BodySculptor.Articles.Data.Entities;
    using BodySculptor.Common.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class ArticlesDbContext : MessageDbContext
    {
        public ArticlesDbContext(DbContextOptions<ArticlesDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleRating> ArticleRatings { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    }
}
