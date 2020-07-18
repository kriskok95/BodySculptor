namespace BodySculptor.Exercises.Services
{
    using BodySculptor.Exercises.Data;
    using BodySculptor.Exercises.Models.MuscleGroups;
    using BodySculptor.Exercises.Services.Interfaces;
    using BodySculptor.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MuscleGroupsService : IMuscleGroupsService
    {
        private readonly ExercisesDbContext context;

        public MuscleGroupsService(ExercisesDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<MuscleGroupDto>> GetAllMuscleGroups()
        {
            return await this.context
                .MuscleGroups
                .To<MuscleGroupDto>()
                .ToListAsync();
        }

        public async Task<bool> IsExistsById(int id)
        {
            return await context
                .MuscleGroups
                .AnyAsync(x => x.Id == id);
        }
    }
}
