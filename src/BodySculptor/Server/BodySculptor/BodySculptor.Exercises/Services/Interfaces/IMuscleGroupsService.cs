namespace BodySculptor.Exercises.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IMuscleGroupsService
    {
        Task<bool> IsExistsById(int id);
    }
}
