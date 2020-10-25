namespace BodySculptor.Administration.Models.Identity
{
    using BodySculptor.Services.Mapping;

    public class UserInputModel : IMapFrom<LoginFormModel>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
