using System.ComponentModel.DataAnnotations;

namespace DocVault.Application.Models.Identity
{
    public class RegistrationRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
