namespace BodySculptor.Common.Messages
{
    using BodySculptor.Common.Data.Entities;
    using Hangfire;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class MessagesHostedService : IHostedService
    {
        private readonly IRecurringJobManager recurringJob;
        private readonly IBus publisher;
        private readonly IServiceProvider services;

        public MessagesHostedService(IRecurringJobManager recurringJob
            , IBus publisher
            , IServiceProvider services)
        {
            this.recurringJob = recurringJob;
            this.publisher = publisher;
            this.services = services;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = this.services.CreateScope();

            var context = scope.ServiceProvider
                    .GetRequiredService<DbContext>();

            if (!context.Database.CanConnect())
            {
                context.Database.Migrate();
            }

            this.recurringJob
                .AddOrUpdate(
                    nameof(MessagesHostedService),
                    () => this.ProcessPendingMessages(),
                    "*/5 * * * * *");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void ProcessPendingMessages()
        {
            using var scope = this.services.CreateScope();

            var context = scope.ServiceProvider
                .GetRequiredService<DbContext>();

            var messages = context
                .Set<Message>()
                .Where(m => !m.Published)
                .ToList();

            foreach (var message in messages)
            {
                this.publisher.Publish(message.Data, message.Type);

                message.MatkAsPublished();

                context.SaveChanges();
            }
        }
    }
}
