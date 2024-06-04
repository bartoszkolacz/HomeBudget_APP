using FluentValidation;
using FluentValidation.AspNetCore;
using HomeBudget.Application.Mappings;
using HomeBudget.Application.Transaction.Commands.CreateTransaction;
using HomeBudget.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Application.Extensions
{
    public static class ServiceCollectionExtensions
        {
            public static void AddApplication(this IServiceCollection services)
            {
            services.AddMediatR(typeof(CreateTransactionCommand));
            services.AddAutoMapper(typeof(TransactionMappingProfile));
            services.AddValidatorsFromAssemblyContaining<CreateTransactionCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            }
        }
    }

