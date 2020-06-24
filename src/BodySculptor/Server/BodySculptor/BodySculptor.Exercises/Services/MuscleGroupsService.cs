namespace BodySculptor.Exercises.Services
{
    using BodySculptor.Exercises.Data;
    using BodySculptor.Exercises.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class MuscleGroupsService : IMuscleGroupsService
    {
        private readonly ExercisesDbContext context;

        public MuscleGroupsService(ExercisesDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsExistsById(int id)
        {
            return await context
                .MuscleGroups
                .AnyAsync(x => x.Id == id);
        }
    }
}
