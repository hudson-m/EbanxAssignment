using EbanxAssignment.Interface;
using EbanxAssignment.Models;
using EbanxAssignment.Repository;

namespace EbanxAssignment.Services
{
    public class Withdraw : BaseTransaction
    {
        private readonly IAccountRepository _accountRepository;
        public Withdraw(IAccountRepository accountRepository) : base()
        {
            _accountRepository = accountRepository;
        }

        public override AccountTransaction? Execute(BankTransaction transaction)
        {
            Account? account = _accountRepository.GetAccounts().Where(x => x.Id == transaction.Origin).FirstOrDefault();

            if (account == null)
                return null;

            account.Balance -= transaction.Amount;

            AccountTransaction account_transaction = new AccountTransaction()
            {
                Origin = account
            };

            _accountRepository.UpdateAccount(account_transaction);

            return account_transaction;
        }
    }
}
