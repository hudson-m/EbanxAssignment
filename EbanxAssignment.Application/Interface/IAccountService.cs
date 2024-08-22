using EbanxAssignment.Models;

namespace EbanxAssignment.Interface
{
    public interface IAccountService
    {
        void ResetState();
        Account GetAccount(string account_id);
    }
}
