using AutoMapper;
using HomeBudget.Application.Transactions;
using HomeBudget.Domain.Interfaces;
using MediatR;


namespace HomeBudget.Application.Transaction.Queries.GetAllTransactions
{
    internal class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;
        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository, IMapper mapper) 
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TransactionDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetAll(); // pobieranie listy elementów
            var dtos = _mapper.Map<IEnumerable<TransactionDto>>(transactions);  //pobieranie list na dto
            return dtos; //zwracanie dto na view
        }
    }
}
