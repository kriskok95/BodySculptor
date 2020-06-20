namespace BodySculptor.Identity.Services.Interfaces
{
    using BodySculptor.Identity.Data.Entities;
    public interface ITokenGeneratorService
    {
        string GenerateToken(User user);
    }
}
