using System;
using System.Collections.Generic;
using System.Linq;
using DesafioNET.Data;
using DesafioNET.Data.Entites;
using DesafioNET.Services.Models;

namespace DesafioNET.Services
{
    public interface ITransactionService : IService
    {
        public TransactionDTO ParseTransaction(string row);

        public void AddTransaction(Guid userId, TransactionDTO dto);

        public bool ChechIfExist(TransactionDTO dto);

        public List<TransactionDTO> GetTransactions(int page);
    }
    public class TransactionService : Service, ITransactionService
    {
        public TransactionService(DataContext db) : base(db)
        {

        }

        public TransactionDTO ParseTransaction(string row)
        {
            var res = new TransactionDTO();

            try
            {
                res.TransactionTypeId = Convert.ToInt32(row.Substring(0, 1));

                res.EventDate = Convert.ToDateTime($"{row.Substring(1,4)}-{row.Substring(5, 2)}-{row.Substring(7, 2)} {row.Substring(42,2)}:{row.Substring(44, 2)}:{row.Substring(46, 2)}");
                
                res.TransactionValue = Convert.ToDecimal(row.Substring(9, 10)) / 100;

                res.CPF = row.Substring(19, 11);

                res.Card = row.Substring(30, 12);

                res.PlaceOwner = row.Substring(48, 14).Trim();
                    
                res.PlaceName = row.Substring(62, row.Length - 62);

                return res;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void AddTransaction(Guid userId, TransactionDTO dto)
        {
            var t = new Transaction
            {
                TransactionId = Guid.NewGuid(),
                TransactionTypeId = dto.TransactionTypeId,
                EventDate = dto.EventDate,
                UserId = userId,
                TransactionValue = dto.TransactionValue,
                CPF = dto.CPF,
                Card = dto.Card,
                PlaceOwner = dto.PlaceOwner,
                PlaceName = dto.PlaceName
            };

            _db.Transactions.Add(t);

        }

        public bool ChechIfExist(TransactionDTO dto)
        {
            return _db.Transactions.Any(x => x.EventDate == dto.EventDate & x.Card == dto.Card);
        }

        public List<TransactionDTO> GetTransactions(int page)
        {
            return _db.Transactions
                .OrderBy(x => x.EventDate)
                .Skip((page - 1 )* 10)
                .Take(10)
                .Select(x => new TransactionDTO(x))
                .ToList();
        }
    }
}