namespace BodySculptor.API.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MuscleGroup : BaseModel<int>
    {
        public string Name { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}
