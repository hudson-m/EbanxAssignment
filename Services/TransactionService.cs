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

        public dynamic Withdraw(string account_id)
        {
            Account? account = _accountRepository.GetAccounts().Where(x => x.Id == account_id).FirstOrDefault();

            if (account == null)
                return null;


            return 0;
        }

        public dynamic Deposit()
        {

        }

        public dynamic Transfer()
        {

        }
    }
}
