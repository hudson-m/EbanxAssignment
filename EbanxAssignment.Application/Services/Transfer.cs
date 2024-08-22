using EbanxAssignment.Interface;
using EbanxAssignment.Models;
using EbanxAssignment.Repository;

namespace EbanxAssignment.Services
{
    public class Transfer : BaseTransaction
    {
        private readonly IAccountRepository _accountRepository;
        public Transfer(IAccountRepository accountRepository) : base()
        {
            _accountRepository = accountRepository;
        }

        public override AccountTransaction? Execute(BankTransaction transaction)
        {
            Account? account_origin = _accountRepository.GetAccounts().Where(x => x.Id == transaction.Origin).FirstOrDefault();
            Account? account_destination = _accountRepository.GetAccounts().Where(x => x.Id == transaction.Destination).FirstOrDefault();

            if (account_origin == null)
                return null;

            if(account_destination == null)
                account_destination  = _accountRepository.CreateAccount(transaction.Destination, transaction.Amount);
            else
                account_destination.Balance += transaction.Amount;

            account_origin.Balance -= transaction.Amount;

            AccountTransaction account_transaction = new AccountTransaction()
            {
                Destination = account_destination,
                Origin = account_origin
            };

            _accountRepository.UpdateAccount(account_transaction);

            return account_transaction;
        }
    }
}
