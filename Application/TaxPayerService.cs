using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class TaxPayerService
    {
        readonly ITaxPayerRepository _taxPayerRepository;

        public TaxPayerService(ITaxPayerRepository taxPayerRepository)
        {
            _taxPayerRepository = taxPayerRepository;
        }

        public async Task<TaxPayer> GetTaxPayerById(Guid id)
        {
            return await _taxPayerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TaxPayer>> GetAllTaxPayersAsync ()
        {
            return await _taxPayerRepository.GetAllAsync();
        }

        public async Task CreateTaxPayerAsync ( TaxPayer taxPayer )
        {
            await _taxPayerRepository.AddAsync(taxPayer);
        }

        public async Task UpdateTaxPayerAsync ( TaxPayer taxPayer )
        {
            await _taxPayerRepository.UpdateAsync(taxPayer);
        }

        public async Task DeleteTaxPayerAsync ( TaxPayer id )
        {
            await _taxPayerRepository.DeleteAsync(id);
        }
    }
}
