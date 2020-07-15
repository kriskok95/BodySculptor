namespace BodySculptor.Identity.Services
{
    using BodySculptor.Identity.Data.Entities;
    using System.Collections.Generic;

    public interface ITokenGeneratorService
    {
        string GenerateToken(User user, IEnumerable<string> roles);
    }
}
