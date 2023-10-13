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
    public class TaxPayerRepository : ITaxPayerRepository
    {
        readonly ApplicationDbContext _context;

        public TaxPayerRepository ( ApplicationDbContext context )
        {
            _context = context;
        }

        public async Task AddAsync ( TaxPayer taxPayer )
        {

            try
            {
                _context.TaxPayers.Add(taxPayer);
                await _context.SaveChangesAsync();
            }
            catch (Exception e) 
            {

                throw;
            }

        }

        public async Task DeleteAsync ( TaxPayer id )
        {
            var item = await _context.TaxPayers.FindAsync(id);
            if (item != null)
            {
                _context.TaxPayers.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaxPayer>> GetAllAsync ()
        {
            return await _context.TaxPayers.ToListAsync();
        }

        public async Task<TaxPayer> GetByIdAsync ( Guid id )
        {
              return await _context.TaxPayers.FindAsync(id);
        }

        public async Task UpdateAsync ( TaxPayer taxPayer )
        {
            _context.Entry(taxPayer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
