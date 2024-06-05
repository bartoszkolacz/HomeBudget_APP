using AutoMapper;
using HomeBudget.Application.ApplicationUser;
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
        private readonly IUserContext _userContext;

        public EditTransactionCommandHandler(ITransactionRepository transactionRepository, IUserContext userContext)
        {
            _transactionRepository = transactionRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByEncodedName(request.EncodedName!);
            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (transaction.CreatedById == user.Id || user.IsInRole("Parent"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            transaction.transactionDescription = request.transactionDescription;
            transaction.transactionCategory = request.transactionCategory;
            transaction.transactionAmount = request.transactionAmount;

            await _transactionRepository.Commit();
            return Unit.Value;
        }

    }
}

