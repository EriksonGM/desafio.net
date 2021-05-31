using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioNET.Data.Entites
{
    public class Transaction
    {
        [Key]
        public Guid TransactionId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public int TransactionTypeId { get; set; }

        [ForeignKey("TransactionTypeId")]
        public TransactionType TransactionType { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public decimal TransactionValue { get; set; }

        [MaxLength(11)]
        [Required]
        public string CPF { get; set; }

        [MaxLength(12)]
        [Required]
        public string Card { get; set; }

        [MaxLength(14)]
        [Required]
        public string PlaceOwner { get; set; }

        [MaxLength(19)]
        [Required]
        public string PlaceName { get; set; }
    }
}