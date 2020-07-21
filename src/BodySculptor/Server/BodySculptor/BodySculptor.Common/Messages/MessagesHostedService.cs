namespace BodySculptor.Common.Messages
{
    using BodySculptor.Common.Data.Entities;
    using Hangfire;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Hosting;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class MessagesHostedService : IHostedService
    {
        private readonly IRecurringJobManager recurringJob;
        private readonly DbContext context;
        private readonly IBus publisher;

        public MessagesHostedService(IRecurringJobManager recurringJob
            , DbContext context
            , IBus publisher)
        {
            this.recurringJob = recurringJob;
            this.context = context;
            this.publisher = publisher;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
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
            var messages = this.context
                .Set<Message>()
                .Where(m => !m.Published)
                .ToList();

            foreach (var message in messages)
            {
                this.publisher.Publish(message.Data, message.Type);

                message.MatkAsPublished();

                this.context.SaveChanges();
            }
        }
    }
}
