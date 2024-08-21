using EbanxAssignment.Models;
using EbanxAssignment.Repository;

namespace EbanxAssignment.Services
{
    public class Transfer : BaseTransaction
    {
        private readonly AccountRepository _accountRepository;
        public Transfer(AccountRepository accountRepository) : base()
        {
            _accountRepository = accountRepository;
        }

        public override AccountTransaction? Execute(BankTransaction transaction)
        {
            Account? account_origin = _accountRepository.GetAccounts().Where(x => x.Id == transaction.Destination).FirstOrDefault();
            Account? account_destination = _accountRepository.GetAccounts().Where(x => x.Id == transaction.Destination).FirstOrDefault();


            if (account_origin == null || account_destination == null)
                return null;

            account_origin.Balance =- transaction.Amount;
            account_destination.Balance =+ transaction.Amount;

            AccountTransaction account_transaction = new AccountTransaction()
            {
                Destination = account_destination,
                Origin = account_origin
            };

            return account_transaction;
        }
    }
}
