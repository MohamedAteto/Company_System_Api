using System.ComponentModel.DataAnnotations;

namespace Company_System_Api.DTOs.AuthDTOs
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
