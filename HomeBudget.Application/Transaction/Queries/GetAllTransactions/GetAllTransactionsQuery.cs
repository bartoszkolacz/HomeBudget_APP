using HomeBudget.Application.Transactions;
using MediatR;


namespace HomeBudget.Application.Transaction.Queries.GetAllTransactions
{
    public class GetAllTransactionsQuery : IRequest<IEnumerable<TransactionCommand>>
    {
        
    } 
}
