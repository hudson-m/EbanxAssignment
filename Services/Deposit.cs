using EbanxAssignment.Models;
using EbanxAssignment.Repository;

namespace EbanxAssignment.Services
{
    public class Deposit : BaseTransaction
    {
        private readonly AccountRepository _accountRepository;
        public Deposit(AccountRepository accountRepository) : base()
        {
            _accountRepository = accountRepository;
        }

        public override AccountTransaction? Execute(BankTransaction transaction)
        {
            Account? account = _accountRepository.GetAccounts().Where(x => x.Id == transaction.Destination).FirstOrDefault();

            if (account == null)
                return null;

            account.Balance = +transaction.Amount;

            AccountTransaction accountTransaction = new AccountTransaction()
            {
                Destination = account
            };

            return accountTransaction;
        }
    }
}
