using System;
using System.Threading.Tasks;
using DesafioNET.Data;

namespace DesafioNET.Services
{
    public interface IService
    {
        void Save();

        Task SaveAsync();
    }

    public abstract class Service : IService
    {
        protected DataContext _db;

        protected Service(DataContext db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
