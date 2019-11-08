using System.ComponentModel.DataAnnotations;

namespace TestWebApi.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
