using AutoMapper;
using HomeBudget.Application.ApplicationUser;
using HomeBudget.Application.Transaction.Commands.DeleteTransaction;
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
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, Unit>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserContext _userContext;

        public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository, IUserContext userContext)
        {
            _transactionRepository = transactionRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByEncodedName(request.EncodedName);
            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (transaction.CreatedById == user.Id || user.IsInRole("Parent"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            await _transactionRepository.Delete(transaction);
            //await _transactionRepository.Commit();

            return Unit.Value;
        }
    }


}

