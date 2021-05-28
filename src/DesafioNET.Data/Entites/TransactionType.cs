using System.ComponentModel.DataAnnotations;

namespace DesafioNET.Data.Entites
{
    public class TransactionType
    {
        [Key]
        public int TransactionTypeId { get; set; }

        [StringLength(50)]
        [Required]
        public string TypeName { get; set; }

        [Required]
        public bool IsPositive { get; set; }
    }
}