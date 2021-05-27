using System.ComponentModel.DataAnnotations;

namespace DesafioNET.Services.Models
{
    public class RegisterDTO
    {
        [MaxLength(100)]
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password",ErrorMessage = "As senhas devem ser iguais")]
        public string Confirmation { get; set; }


    }
}