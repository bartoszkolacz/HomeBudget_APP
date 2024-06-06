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
        private readonly IUserContext _userContext;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper, IUserContext userContext) 
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null /*|| !currentUser.IsInRole("Owner")*/) 
            {
                return Unit.Value;
            }
            var transaction = _mapper.Map<HomeBudget.Domain.Entities.Transaction>(request);
            transaction.EncodeName();

            transaction.CreatedById = currentUser.Id;
            await _transactionRepository.Create(transaction);
            return Unit.Value;
        }

    }
}
