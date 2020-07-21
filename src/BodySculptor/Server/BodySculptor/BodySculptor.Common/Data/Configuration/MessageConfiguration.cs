namespace BodySculptor.Common.Data.Configuration
{
    using BodySculptor.Common.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property<string>("serializedData")
                .IsRequired()
                .HasField("serializedData");

            builder
                .Property(m => m.Type)
                .IsRequired()
                .HasConversion(
                    t => t.AssemblyQualifiedName,
                    t => Type.GetType(t));
        }
    }
}
