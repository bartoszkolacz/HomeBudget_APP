using AutoMapper;
using HomeBudget.Application.Transactions;
using HomeBudget.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Application.Transaction.Queries.GetAllTransactions
{
    internal class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionCommand>>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;
        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository, IMapper mapper) 
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TransactionCommand>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetAll(); // pobieranie listy elementów
            var dtos = _mapper.Map<IEnumerable<TransactionCommand>>(transactions);  //pobieranie list na dto
            return dtos; //zwracanie dto na view
        }
    }
}
