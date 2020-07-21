namespace BodySculptor.Common.Data
{
    using BodySculptor.Common.Data.Configuration;
    using BodySculptor.Common.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public abstract class MessageDbContext : DbContext
    {
        protected MessageDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }
        protected abstract Assembly ConfigurationsAssembly { get; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfigurationsFromAssembly(this.ConfigurationsAssembly);

            base.OnModelCreating(builder);
        }

    }
}
