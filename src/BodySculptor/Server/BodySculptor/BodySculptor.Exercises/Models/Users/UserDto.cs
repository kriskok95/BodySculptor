namespace BodySculptor.Exercises.Models.Users
{
    using BodySculptor.Exercises.Data.Entities;
    using BodySculptor.Services.Mapping;

    public class UserDto : IMapFrom<User>
    {
        public int Id { get; set; }
    }
}
