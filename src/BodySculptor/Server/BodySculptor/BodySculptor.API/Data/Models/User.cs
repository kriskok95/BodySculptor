namespace BodySculptor.API.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public ICollection<ExercisePractice> ExercisePractices { get; set; }

        public ICollection<TrainingSession> TrainingSessions { get; set; }

        public ICollection<DailyMenu> DailyMenus { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
 