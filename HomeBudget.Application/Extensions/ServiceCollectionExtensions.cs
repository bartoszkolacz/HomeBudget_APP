using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using HomeBudget.Application.ApplicationUser;
using HomeBudget.Application.Mappings;
using HomeBudget.Application.Transaction.Commands.CreateTransaction;
using HomeBudget.Application.Transaction.Commands.EditTransaction;
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
            services.AddScoped<IUserContext, UserContext>();
            services.AddMediatR(typeof(CreateTransactionCommand));

            //services.AddMediatR(typeof(EditTransactionCommand));
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new TransactionMappingProfile(userContext));
            }).CreateMapper()
            ); //mapper odczytuje jaki użytkownik korzysta z apki i sprawdzic czy ma dostep do edycji danego zasobu transactiondto

            services.AddValidatorsFromAssemblyContaining<CreateTransactionCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            }
        }
    }

