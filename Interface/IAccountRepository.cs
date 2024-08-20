using EbanxAssignment.Models;

namespace EbanxAssignment.Interface
{
    public interface IAccountRepository
    {
        List<Account> GetAccounts();
    }
}
