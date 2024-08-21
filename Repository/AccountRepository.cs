using EbanxAssignment.Interface;
using EbanxAssignment.Models;

namespace EbanxAssignment.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private List<Account> _accounts;

        public AccountRepository()
        {
            _accounts = new List<Account>
            {
                new Account()
                {
                    Id="300",
                    Balance = 0
                }
            };
        }

        public List<Account> GetAccounts()
        {
            return _accounts;
        }

        public void CreateAccount(Account account)
        {
            _accounts.Add(account);
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
