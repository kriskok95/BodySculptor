namespace BodySculptor.Exercises.Services.Interfaces
{
    using BodySculptor.Exercises.Models.MuscleGroups;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMuscleGroupsService
    {
        Task<bool> IsExistsById(int id);

        Task<IEnumerable<MuscleGroupDto>> GetAllMuscleGroups();
    }
}
