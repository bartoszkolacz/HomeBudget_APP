using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task Create(Domain.Entities.Transaction transaction);
        Task<Domain.Entities.Transaction?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.Transaction>> GetAll(); 
    }
}
