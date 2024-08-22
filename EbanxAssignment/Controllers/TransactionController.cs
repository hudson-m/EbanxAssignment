using EbanxAssignment.Interface;
using EbanxAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace EbanxAssignment.Controllers
{
    [ApiController]
    [Route("")]
    public class TransactionController : Controller
    {
        public readonly ITransactionService _transactionService;
        public readonly IAccountService _accountService;

        public TransactionController(ITransactionService transactionService, IAccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }

        [HttpPost]
        [Route("reset")]
        public IActionResult ResetState()
        {
            _accountService.ResetState();
            return StatusCode(200);
        }

        [HttpGet]
        [Route("balance")]
        public ActionResult GetBalance(string account_id)
        {
            Account account = _accountService.GetAccount(account_id);

            if (account == null)
                return NotFound(0);

            return Ok(account.Balance);
        }

        [HttpPost]
        [Route("event")]
        public ActionResult BankTransaction([FromBody] BankTransaction transaction)
        {
            AccountTransaction? account_transaction = _transactionService.TransactionEvent(transaction);

            if(account_transaction == null)
                return NotFound(0);

            return Created(string.Empty, account_transaction);
        }
    }
}
