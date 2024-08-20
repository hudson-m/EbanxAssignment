using EbanxAssignment.Models;

namespace EbanxAssignment.Interface
{
    public interface IAccountService
    {
        Account GetAccount(string account_id);
    }
}
