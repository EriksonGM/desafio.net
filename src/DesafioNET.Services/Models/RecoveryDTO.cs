using System.ComponentModel.DataAnnotations;

namespace DesafioNET.Services.Models
{
    public class RecoveryDTO
    {
        [EmailAddress]
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}