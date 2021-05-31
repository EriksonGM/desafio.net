using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesafioNET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioNET.Data;
using DesafioNET.Services.Tests.Configuration;

namespace DesafioNET.Services.Tests
{
    [TestClass]
    public class TransactionServiceTests
    {
        private readonly DataContext _db;
        private readonly TransactionService _transaction;

        public TransactionServiceTests()
        {
            _db = TestDataContext.GetInMemory();
            _transaction = new TransactionService(_db);
        }

        [TestMethod]
        [DataRow("2201903010000010700845152540738723****9987123333MARCOS PEREIRAMERCADO DA AVENIDA")]
        [DataRow("1201903010000015200096206760171234****7890233000JOÃO MACEDO   BAR DO JOÃO")]
        [DataRow("3201903010000060200232702980566777****1313172712JOSÉ COSTA    MERCEARIA 3 IRMÃOS")]
        public void ParseTransaction_Test(string row)
        {
            var res = _transaction.ParseTransaction(row);

            Assert.IsNotNull(res);
            //Assert.AreEqual(res.);
        }
    }
}