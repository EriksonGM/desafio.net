using System;
using DesafioNET.Data;
using DesafioNET.Services.Models;

namespace DesafioNET.Services
{
    public interface ITransactionService : IService
    {
        public TransactionDTO ParseTransaction(string row);
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
                
                res.TransactionValue = Convert.ToDecimal(row.Substring(9, 19));

                res.CPF = row.Substring(19, 11);

                res.Card = row.Substring(30, 13);

                res.PlaceOwner = row.Substring(48, 14).Trim();

                res.PlaceName = row.Substring(62, row.Length - 62);

                return res;
            }
            catch (Exception e)
            {
                return null;
            }

            
        }
    }
}