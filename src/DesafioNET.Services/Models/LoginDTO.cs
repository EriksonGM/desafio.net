using System.ComponentModel.DataAnnotations;

namespace DesafioNET.Services.Models
{
    public class LoginDTO
    {
        [EmailAddress]
        [Required]
        [MaxLength(50)]
        [Display(Name = "Endereço de email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Senha")]
        public string Password { get; set; } 
    }
}