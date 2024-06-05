using AutoMapper;
using HomeBudget.Application.Transaction.Commands.EditTransaction;
using HomeBudget.Application.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Application.Mappings
{
    public class TransactionMappingProfile : Profile
    {
        public TransactionMappingProfile()
        {
            CreateMap<TransactionDto, Domain.Entities.Transaction>(); //mapowanie z dto do encji bazodanowej
            CreateMap<Domain.Entities.Transaction, TransactionDto>(); //mapowanie z encji bazodanowej do dto
            CreateMap<TransactionDto, EditTransactionCommand>();        //mapowanie z dto na obiekt do edycji
        }

    }
}
