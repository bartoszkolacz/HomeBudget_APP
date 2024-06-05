
using AutoMapper;
using HomeBudget.Application.Transactions;
using HomeBudget.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Application.Transaction.Queries.GetTransactionByEncodedName
{
    public class GetTransactionByEncodedNameQueryHandler : IRequestHandler<GetTransactionByEncodedNameQuery, TransactionDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionByEncodedNameQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository; 
            _mapper = mapper;
        }
        public async Task<TransactionDto> Handle(GetTransactionByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<TransactionDto>(transaction);
            return dto;
        }
    }
}
