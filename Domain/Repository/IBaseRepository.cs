using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByIdAsync ( Guid id );
        Task<IEnumerable<T>> GetAllAsync ();
        Task AddAsync ( T entity );
        Task UpdateAsync ( T entity );
        Task DeleteAsync ( T entity );
    }
}
