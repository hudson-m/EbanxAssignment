using EbanxAssignment.Interface;
using EbanxAssignment.Models;
using EbanxAssignment.Repository;

namespace EbanxAssignment.Services
{
    public class CreateAccount : BaseTransaction
    {
        private readonly IAccountRepository _accountRepository;
        public CreateAccount(IAccountRepository accountRepository) : base()
        {
            _accountRepository = accountRepository;
        }

        public override AccountTransaction? Execute(BankTransaction transaction)
        {
            Account? account = _accountRepository.CreateAccount(transaction.Destination, transaction.Amount);

            if (account == null)
                return null;

            account.Balance = +transaction.Amount;

            AccountTransaction account_transaction = new AccountTransaction()
            {
                Destination = account
            };

            _accountRepository.UpdateAccount(account_transaction);

            return account_transaction;
        }
    }
}
