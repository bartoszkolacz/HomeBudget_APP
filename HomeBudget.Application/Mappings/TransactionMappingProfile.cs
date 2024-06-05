using AutoMapper;
using HomeBudget.Application.ApplicationUser;
using HomeBudget.Application.Transaction.Commands.EditTransaction;
using HomeBudget.Application.TransactionCategory;
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
        public TransactionMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<TransactionDto, EditTransactionCommand>();      //mapowanie z dto na obiekt do edycji
            CreateMap<TransactionDto, Domain.Entities.Transaction>(); //mapowanie z dto do encji bazodanowej
            CreateMap<Domain.Entities.Transaction, TransactionDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null
                                            && (src.CreatedById == user.Id || user.IsInRole("Parent")))); //mapowanie z encji bazodanowej do dto

            CreateMap<TransactionCategoryDto, Domain.Entities.TransactionCategories>()
                .ReverseMap();


            

        }

    }
}
