using EbanxAssignment.Interface;
using EbanxAssignment.Models;

namespace EbanxAssignment.Services
{
    public class Deposit : BaseTransaction
    {
        private readonly IAccountRepository _accountRepository;
        public Deposit(IAccountRepository accountRepository) : base()
        {
            _accountRepository = accountRepository;
        }

        public override AccountTransaction? Execute(BankTransaction transaction)
        {
            AccountTransaction account_transaction = new AccountTransaction();
            Account? account = _accountRepository.GetAccounts().Where(x => x.Id == transaction.Destination).FirstOrDefault();

            if (account == null)
                account = _accountRepository.CreateAccount(transaction.Destination, transaction.Amount);
            else
                account.Balance += transaction.Amount;

            account_transaction.Destination = account;

            _accountRepository.UpdateAccount(account_transaction);

            return account_transaction;
        }
    }
}
