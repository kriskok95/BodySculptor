namespace BodySculptor.Articles.Models.Users
{
    using BodySculptor.Articles.Data.Entities;
    using BodySculptor.Services.Mapping;

    public class UserDto : IMapFrom<User>
    {
        public int Id { get; set; }
    }
}
