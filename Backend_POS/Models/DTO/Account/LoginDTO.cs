using System.ComponentModel.DataAnnotations;

namespace Backend_POS.Models.DTO.Account
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
