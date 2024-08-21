using EbanxAssignment.Interface;
using EbanxAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EbanxAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        public readonly ITransactionService _transactionService;
        public readonly IAccountService _accountService;

        public TransactionController(ITransactionService transactionService, IAccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }

        // GET: TransactionController
        public ActionResult GetBalance(string account_id)
        {
            Account account = _accountService.GetAccount(account_id);

            if (account == null)
                return NotFound(0);

            return View(account.Balance);
        }

        [HttpPost]
        public ActionResult BankTransaction([FromBody] BankTransaction transaction)
        {


            return View();
        }
    }
}
