using AutoMapper;
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
            CreateMap<TransactionCommand, Domain.Entities.Transaction>(); //mapowanie z dto do encji bazodanowej
            CreateMap<Domain.Entities.Transaction, TransactionCommand>(); //mapowanie z encji bazodanowej do dto
        }

    }
}
