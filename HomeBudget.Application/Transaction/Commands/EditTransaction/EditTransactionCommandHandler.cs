using AutoMapper;
using HomeBudget.Application.Transactions;
using HomeBudget.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Application.Transaction.Commands.EditTransaction
{
    public class EditTransactionCommandHandler : IRequestHandler<EditTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;

        public EditTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Unit> Handle(EditTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByEncodedName(request.EncodedName!);

            transaction.transactionDescription = request.transactionDescription;
            transaction.transactionCategory = request.transactionCategory;
            transaction.transactionAmount = request.transactionAmount;

            await _transactionRepository.Commit();
            return Unit.Value;
        }

    }
}

