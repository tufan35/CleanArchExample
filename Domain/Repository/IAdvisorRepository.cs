using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IAdvisorRepository : IBaseRepository<Advisor>
    {
        Task<IEnumerable<TaxPayer>> GetAllTaxPayerAsync ( Guid advisorId );
    }
}
