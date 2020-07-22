namespace BodySculptor.Statistics.Data
{
    using BodySculptor.Common.Data;
    using BodySculptor.Statistics.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class StatisticsDbContext : MessageDbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
            : base(options)
        {

        }

        public DbSet<AdministrationStatistics> AdministrationStatistics { get; set; }
        public DbSet<ClientStatistics> ClientStatistics { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    }
}
