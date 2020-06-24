namespace BodySculptor.Articles.Data
{
    using BodySculptor.Articles.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ArticlesDbContext : DbContext
    {
        public ArticlesDbContext(DbContextOptions<ArticlesDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleRating> ArticleRatings { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Article>()
                .HasOne(x => x.ArticleRating)
                .WithOne(x => x.Article)
                .HasForeignKey<ArticleRating>(x => x.ArticleId);
        }
    }
}
