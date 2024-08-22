using EbanxAssignment.Models;

namespace EbanxAssignment.Interface
{
    public interface IAccountRepository
    {
        void ResetState();
        List<Account> GetAccounts();
        Account CreateAccount(string account_id, decimal amount);
        void UpdateAccount(AccountTransaction account_transaction);
    }
}
