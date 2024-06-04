using HomeBudget.Application.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Application.Transaction.Commands.CreateTransaction
{
    public class CreateTransactionCommand : TransactionCommand, IRequest 
    {

    }
}
