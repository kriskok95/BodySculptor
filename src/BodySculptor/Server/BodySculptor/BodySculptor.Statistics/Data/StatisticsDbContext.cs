namespace BodySculptor.Statistics.Data
{
    using BodySculptor.Statistics.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class StatisticsDbContext : DbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
            : base(options)
        {

        }

        public DbSet<AdministrationStatistics> AdministrationStatistics { get; set; }
        public DbSet<ClientStatistics> ClientStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
