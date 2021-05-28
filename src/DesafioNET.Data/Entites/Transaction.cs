using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioNET.Data.Entites
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int TransactionTypeId { get; set; }

        [ForeignKey("TransactionTypeId")]
        public TransactionType TransactionType { get; set; }

        public DateTime EventDate { get; set; }


        public decimal TransactionValue { get; set; }

        [MaxLength(10)]
        [Required]
        public string CPF { get; set; }

        [MaxLength(11)]
        [Required]
        public string Card { get; set; }

        [MaxLength(13)]
        [Required]
        public string PlaceOwner { get; set; }

        [MaxLength(18)]
        [Required]
        public string PlaceName { get; set; }
    }
}