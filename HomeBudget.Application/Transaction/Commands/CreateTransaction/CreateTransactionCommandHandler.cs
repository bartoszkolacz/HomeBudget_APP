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

namespace HomeBudget.Application.Transaction.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper, IUserContext) 
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<HomeBudget.Domain.Entities.Transaction>(request);
            transaction.EncodeName();

            transaction.CreatedById = _userContext.GetCurrentUser().Id;
            await _transactionRepository.Create(transaction);
            return Unit.Value;
        }

    }
}
