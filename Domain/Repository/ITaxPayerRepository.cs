using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ITaxPayerRepository
    {
        Task<TaxPayer> GetByIdAsync ( Guid id );
        Task<IEnumerable<TaxPayer>> GetAllAsync ();
        Task AddAsync ( TaxPayer taxPayer );
        Task UpdateAsync ( TaxPayer taxPayer );
        Task DeleteAsync ( TaxPayer id );
    }
}
