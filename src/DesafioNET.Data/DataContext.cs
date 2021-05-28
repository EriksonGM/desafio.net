using DesafioNET.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace DesafioNET.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType{TransactionTypeId = 1, TypeName = "Débito", IsPositive = true},
                new TransactionType{TransactionTypeId = 2, TypeName = "Boleto", IsPositive = false },
                new TransactionType{TransactionTypeId = 3, TypeName = "Financiamento", IsPositive = false},
                new TransactionType{TransactionTypeId = 4, TypeName = "Crédito", IsPositive = true},
                new TransactionType{TransactionTypeId = 5, TypeName = "Recebimento Empréstimo", IsPositive = true},
                new TransactionType{TransactionTypeId = 6, TypeName = "Vendas", IsPositive = true},
                new TransactionType{TransactionTypeId = 7, TypeName = "Recebimento TED", IsPositive = true},
                new TransactionType{TransactionTypeId = 8, TypeName = "Recebimento DOC", IsPositive = true},
                new TransactionType{TransactionTypeId = 9, TypeName = "Aluguel", IsPositive = false }
                );

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }
    }
}