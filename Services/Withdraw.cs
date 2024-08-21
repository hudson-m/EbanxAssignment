using EbanxAssignment.Models;
using EbanxAssignment.Repository;

namespace EbanxAssignment.Services
{
    public class Withdraw : BaseTransaction
    {
        private readonly AccountRepository _accountRepository;
        public Withdraw(AccountRepository accountRepository) : base()
        {
            _accountRepository = accountRepository;
        }

        public override AccountTransaction? Execute(BankTransaction transaction)
        {
            Account? account = _accountRepository.GetAccounts().Where(x => x.Id == transaction.Destination).FirstOrDefault();

            if (account == null)
                return null;

            account.Balance =- transaction.Amount;

            AccountTransaction accountTransaction = new AccountTransaction()
            {
                Origin = account
            };

            return accountTransaction;
        }
    }
}
