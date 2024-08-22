using EbanxAssignment.Interface;
using EbanxAssignment.Models;

namespace EbanxAssignment.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private List<Account> _accounts;

        public AccountRepository()
        {
            _accounts = new List<Account>();
        }

        public void ResetState()
        {
            _accounts.Clear();
        }

        public List<Account> GetAccounts()
        {
            return _accounts;
        }

        public Account CreateAccount(string account_id, decimal amount)
        {
            Account account = new Account()
            {
                Id = account_id,
                Balance = amount
            };

            _accounts.Add(account);

            return account;
        }

        public void UpdateAccount(AccountTransaction account_transaction)
        {
            if (account_transaction.Origin != null)
            {
                Account account_updated_origin = _accounts.FirstOrDefault(x => x.Id == account_transaction.Origin.Id);
                account_updated_origin.Balance = account_transaction.Origin.Balance;
            }
            if (account_transaction.Destination != null)
            {
                Account account_updated_destination = _accounts.FirstOrDefault(x => x.Id == account_transaction.Destination.Id);
                account_updated_destination.Balance = account_transaction.Destination.Balance;
            }
        }
    }
}
