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
        public string CPF { get; set; }

        [MaxLength(11)]
        public string Card { get; set; }

        [MaxLength(13)]
        public string PlaceOwner { get; set; }

        [MaxLength(18)]
        public string PlaceName { get; set; }
    }
}