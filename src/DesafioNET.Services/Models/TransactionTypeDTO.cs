using System.ComponentModel.DataAnnotations;
using DesafioNET.Data.Entites;

namespace DesafioNET.Services.Models
{
    public class TransactionTypeDTO
    {
        public TransactionTypeDTO()
        {
            
        }

        public TransactionTypeDTO(TransactionType t)
        {
            TransactionTypeId = t.TransactionTypeId;
            TypeName = t.TypeName;
            IsPositive = t.IsPositive;
        }

        public int TransactionTypeId { get; set; }

        [StringLength(50)]
        [Required]
        public string TypeName { get; set; }

        [Required]
        public bool IsPositive { get; set; }
    }
}