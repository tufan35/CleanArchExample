using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AdvisorService
    {
        readonly IAdvisorRepository _advisorRepository;

        public AdvisorService ( IAdvisorRepository advisorRepository)
        {
            _advisorRepository = advisorRepository;
        }

        public async Task<Advisor> GetAdvisorById(Guid id)
        {
            return await _advisorRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Advisor>> GetAllAdvisorsAsync ()
        {
            return await _advisorRepository.GetAllAsync();
        }

        public async Task CreateAdvisorAsync ( Advisor advisor )
        {
            await _advisorRepository.AddAsync(advisor);
        }

        public async Task UpdateAdvisorAsync ( Advisor advisor )
        {
            await _advisorRepository.UpdateAsync(advisor);
        }

        public async Task DeleteAdvisorAsync ( Advisor id )
        {
            await _advisorRepository.DeleteAsync(id);
        }
    }
}
