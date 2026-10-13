using System.ComponentModel.DataAnnotations;

namespace Company_System_Api.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required , StringLength(150 , MinimumLength = 20)]
        public string Username { get; set; }
        [Required,EmailAddress,MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Password { get; set; }
        [Required, MaxLength(30)]
        public string Role{ get; set; } = "Employee";

    }
}
