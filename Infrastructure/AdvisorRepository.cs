using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AdvisorRepository : IAdvisorRepository
    {
        readonly ApplicationDbContext _context;

        public AdvisorRepository ( ApplicationDbContext context )
        {
            _context = context;
        }

        public async Task AddAsync ( Advisor entity )
        {
            _context.Advisors.Add(entity);
            await _context.SaveChangesAsync();
          
        }

        public async Task DeleteAsync ( Advisor entity )
        {

            var item = await _context.Advisors.FindAsync(entity);
            if (item != null)
            {
                _context.Advisors.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Advisor>> GetAllAsync ()
        {
            return await _context.Advisors.ToListAsync();
        }

        public async Task<IEnumerable<TaxPayer>> GetAllTaxPayerAsync ( Guid advisorId )
        {
            return null;
            //return await _context.Advisors.Where(s => s.Id==advisorId).Select(p=> p.TaxPayers);
        }

        public async Task<Advisor> GetByIdAsync ( Guid id )
        {
            return await _context.Advisors.FindAsync(id);
        }

        public async Task UpdateAsync ( Advisor entity )
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        
    }
}
