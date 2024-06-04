using HomeBudget.Domain.Entities;

namespace HomeBudget.Application.Services
{
    public interface ITransactionService
    {
        Task Create(Transaction transaction);
    }
}