using EbanxAssignment.Interface;
using EbanxAssignment.Models;

namespace EbanxAssignment.Services
{
    public abstract class BaseTransaction : IBaseTransaction
    {
        public BaseTransaction() { }

        public abstract AccountTransaction? Execute(BankTransaction transaction);
    }
}
