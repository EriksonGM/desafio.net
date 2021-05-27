using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioNET.Data.Entites
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }
    }
}