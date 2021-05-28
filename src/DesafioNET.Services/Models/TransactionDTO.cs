using System;
using System.ComponentModel.DataAnnotations;
using DesafioNET.Data.Entites;

namespace DesafioNET.Services.Models
{
    public class TransactionDTO
    {
        public TransactionDTO()
        {
            
        }

        public TransactionDTO(Transaction t)
        {
            TransactionId = t.TransactionId;
            UserId = t.UserId;
            TransactionTypeId = t.TransactionTypeId;
            EventDate = t.EventDate;
            TransactionValue = t.TransactionValue;
            CPF = t.CPF;
            Card = t.Card;
            PlaceName = t.PlaceName;
            PlaceOwner = t.PlaceOwner;

            if(t.User != null)
                User = new UserDTO(t.User);

            if(t.TransactionType != null)
                TransactionTypeDTO = new TransactionTypeDTO(t.TransactionType);

        }

        public Guid TransactionId { get; set; }

        public Guid UserId { get; set; }

        public UserDTO User { get; set; }

        public int TransactionTypeId { get; set; }

        public TransactionTypeDTO TransactionTypeDTO { get; set; }

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