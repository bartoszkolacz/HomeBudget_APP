using HomeBudget.Application.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Application.Transaction.Queries.GetTransactionByEncodedName
{
    public class GetTransactionByEncodedNameQuery : IRequest<TransactionDto>
    {
        public string EncodedName { get; set; }

        public GetTransactionByEncodedNameQuery(string encodedName) 
        {
            EncodedName = encodedName;
        }
    }
}
