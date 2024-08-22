using EbanxAssignment.Models;

namespace EbanxAssignment.Interface
{
    public interface IBaseTransaction
    {
        abstract AccountTransaction? Execute(BankTransaction transaction);
    }
}
