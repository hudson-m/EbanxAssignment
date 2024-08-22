using EbanxAssignment.Models;

namespace EbanxAssignment.Interface
{
    public interface ITransactionService
    {
        AccountTransaction? TransactionEvent(BankTransaction bank_transaction);
    }
}
