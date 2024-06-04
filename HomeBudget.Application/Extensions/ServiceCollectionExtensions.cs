using HomeBudget.Application.Services;
using HomeBudget.Domain.Interfaces;
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
            services.AddScoped<ITransactionService, TransactionService>();
            }
        }
    }

