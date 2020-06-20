namespace BodySculptor.Identity.Services
{
    using BodySculptor.Identity.Data.Entities;
    public interface ITokenGeneratorService
    {
        string GenerateToken(User user);
    }
}
