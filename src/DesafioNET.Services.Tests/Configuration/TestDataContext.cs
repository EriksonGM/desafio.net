using DesafioNET.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioNET.Services.Tests.Configuration
{
    public static class TestDataContext
    {
        public static DataContext GetInMemory()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("MemoryDB")
                .Options;

            return new DataContext(options);
        }
    }
}