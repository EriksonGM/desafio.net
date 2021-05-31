using DesafioNET.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DesafioNET.Services;
using DesafioNET.Services.Helpers;
using DesafioNET.Services.Models;
using Microsoft.AspNetCore.Http;

namespace DesafioNET.UI.Controllers
{

    public class HomeController : BaseController
    {
        private readonly ITransactionService _transaction;
        public HomeController(ITransactionService transaction)
        {
            _transaction = transaction;
        }

        public IActionResult Index()
        {


            return View();
        }


        public IActionResult Account()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ImportFile(IFormFile file)
        {
            var stream = file.OpenReadStream();

            var transactions = new List<TransactionDTO>();

            var result = new List<ImportedTransactionResultDTO>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var t = _transaction.ParseTransaction(line);

                    if (t == null)
                        result.Add(new ImportedTransactionResultDTO
                        {
                            Result = "Registo inválido",
                            Success = false,
                            Row = line,
                            Transaction = null
                        });
                    else
                    {
                        if (_transaction.ChechIfExist(t))
                            result.Add(new ImportedTransactionResultDTO
                            {
                                Result = "Registo ja existente",
                                Success = false,
                                Row = line,
                                Transaction = null
                            });
                        else
                        {
                            try
                            {

                                _transaction.AddTransaction(User.GetId(), t);

                                _transaction.Save();

                                result.Add(new ImportedTransactionResultDTO
                                {
                                    Transaction = t,
                                    Success = true,
                                    Result = "Registo importado com sucesso",
                                    Row = line
                                });
                            }
                            catch (Exception e)
                            {
                                result.Add(new ImportedTransactionResultDTO
                                {
                                    Transaction = t,
                                    Success = false,
                                    Result = e.Message,
                                    Row = line
                                });
                            }
                        }
                    }
                }
            }

            return View(result);
        }

        [HttpGet]
        [Route("History/{page:int}")]
        public IActionResult History(int page = 1)
        {
            return View(page);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
