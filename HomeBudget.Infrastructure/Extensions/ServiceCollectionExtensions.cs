using HomeBudget.Domain.Interfaces;
using HomeBudget.Infrastructure.Persistence;
using HomeBudget.Infrastructure.Repositories;
using HomeBudget.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void  AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HomeBudgetDbContext>(options => options.UseSqlServer(
        configuration.GetConnectionString("HomeBudget"))); //połączenie bazy danych ze ścieżki w appsettings.json

            services.AddScoped<TransactionSeeder>();

            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
