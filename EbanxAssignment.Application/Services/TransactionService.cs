using EbanxAssignment.Interface;
using EbanxAssignment.Models;
using EbanxAssignment.Repository;
using System.Transactions;

namespace EbanxAssignment.Services
{
    public class TransactionService : ITransactionService
    {
        public readonly IAccountRepository _account_repository;

        public TransactionService(IAccountRepository account_repository)
        {
            _account_repository = account_repository;
        }

        public AccountTransaction? TransactionEvent(BankTransaction bank_transaction)
        {
            switch(bank_transaction.Type)
            {
                case "deposit":
                    return DepositEvent(bank_transaction);
                case "withdraw":
                    return WithdrawEvent(bank_transaction);
                case "transfer":
                    return TransferEvent(bank_transaction);
                default:
                    return null;
            }
        }

        internal AccountTransaction? DepositEvent(BankTransaction transaction)
        {
            BaseTransaction deposit = new Deposit(_account_repository);

            AccountTransaction? account_transaction = deposit.Execute(transaction);

            return account_transaction;
        }

        internal AccountTransaction? WithdrawEvent(BankTransaction transaction)
        {
            BaseTransaction withdraw = new Withdraw(_account_repository);

            AccountTransaction? account_transaction = withdraw.Execute(transaction);

            return account_transaction;
        }

        internal AccountTransaction? TransferEvent(BankTransaction transaction)
        {
            BaseTransaction transfer = new Transfer(_account_repository);

            AccountTransaction? account_transaction = transfer.Execute(transaction);

            return account_transaction;
        }
    }
}
