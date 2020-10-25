namespace BodySculptor.Articles.Messages
{
    using BodySculptor.Articles.Services.Interfaces;
    using BodySculptor.Common.Messages.Identity;
    using MassTransit;
    using System.Threading.Tasks;

    public class UserCreatedConsumer : IConsumer<UserCreatedMessage>
    {
        private readonly IUsersService usersService;

        public UserCreatedConsumer(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async Task Consume(ConsumeContext<UserCreatedMessage> context)
        {
            var message = context.Message;

            await this.usersService.RegisterUser(message.UserId);
        }
    }
}
