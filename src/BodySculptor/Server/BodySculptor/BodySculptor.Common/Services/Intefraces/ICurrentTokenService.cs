namespace BodySculptor.Common.Services.Intefraces
{
    public interface ICurrentTokenService
    {
        string Get();

        void Set(string token);
    }
}
