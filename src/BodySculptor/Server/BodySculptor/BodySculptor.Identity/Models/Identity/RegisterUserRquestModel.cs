namespace BodySculptor.Identity.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserRquestModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
