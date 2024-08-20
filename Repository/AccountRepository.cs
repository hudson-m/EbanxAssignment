using EbanxAssignment.Interface;
using EbanxAssignment.Models;
using System.Transactions;

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

        public bool UpdateAccount(BankTransaction transaction)
        {
            switch (transaction.Type)
            {
                case "deposit" or "withdraw":
                    Account account = _accounts.Where(x => x.Id == transaction.Destination).FirstOrDefault();

                    if (account == null)
                        return false;

                    if(transaction.Type == "deposit")
                        account.Balance =+ transaction.Amount;
                    else
                        account.Balance =- transaction.Amount;

                    break;
                case "transfer":
                    Account? origin_account = _accounts.Where(x => x.Id == transaction.Origin).FirstOrDefault();
                    Account? destination_account = _accounts.Where(x => x.Id == transaction.Destination).FirstOrDefault();

                    if (origin_account == null)
                        return false;
                    if (destination_account == null) 
                        return false;

                    break;
                default:
                    break;

            }

            return true;
        }
    }
}
