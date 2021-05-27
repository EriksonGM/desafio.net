using System;
using System.ComponentModel.DataAnnotations;
using DesafioNET.Data.Entites;

namespace DesafioNET.Services.Models
{
    public class UserDTO
    {

        public UserDTO()
        {
            
        }

        public UserDTO(User u)
        {
            UserId = u.UserId;
            Name = u.Name;
            Email = u.Email;
        }

        public Guid UserId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }



    }
}