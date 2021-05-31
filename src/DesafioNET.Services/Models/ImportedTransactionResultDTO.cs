namespace DesafioNET.Services.Models
{
    public class ImportedTransactionResultDTO
    {
        public string Row { get; set; }

        public string Result { get; set; }

        public bool Success { get; set; }

        public TransactionDTO Transaction { get; set; }
    }
}