namespace BodySculptor.Nutrition.Models.Users
{
    using BodySculptor.Nutrition.Data.Entities;
    using BodySculptor.Services.Mapping;

    public class UserDto : IMapFrom<User>
    {
        public int Id { get; set; }
    }
}
