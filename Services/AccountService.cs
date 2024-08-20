using EbanxAssignment.Interface;
using EbanxAssignment.Models;

namespace EbanxAssignment.Services
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account GetAccount(string account_id)
        {
            Account? account = _accountRepository.GetAccounts().Where(x => x.Id == account_id).FirstOrDefault();

            return account;
        }
    }
}
