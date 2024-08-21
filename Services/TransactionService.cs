using EbanxAssignment.Interface;
using EbanxAssignment.Models;

namespace EbanxAssignment.Services
{
    public class TransactionService : ITransactionService
    {
        public readonly IAccountRepository _accountRepository;

        public TransactionService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
    }
}
