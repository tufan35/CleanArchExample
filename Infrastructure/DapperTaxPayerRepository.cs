using Dapper;
using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DapperTaxPayerRepository : ITaxPayerRepository
    {
        private readonly IDbConnection _dbConnection;

        public DapperTaxPayerRepository ( IDbConnection dbConnection )
        {
            _dbConnection = dbConnection;
        }

        public async Task AddAsync ( TaxPayer taxPayer )
        {
            string sql = "INSERT INTO public.TaxPayers (Id, Identity, Address, NaceCode, Obligation, Application) VALUES (@Id, @Identity, @Address, @NaceCode, @Obligation, @Application)";
            await _dbConnection.ExecuteAsync(sql, taxPayer);
        }

        public async Task DeleteAsync ( TaxPayer id )
        {
            string sql = "DELETE FROM public.TaxPayers WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<TaxPayer>> GetAllAsync ()
        {
            string sql = "SELECT * FROM taxpayers";
            return await _dbConnection.QueryAsync<TaxPayer>(sql);
        }

        public async Task<TaxPayer> GetByIdAsync ( Guid id )
        {
            string sql = "SELECT * FROM taxpayers WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<TaxPayer>(sql, new { Id = id });
        }
    

        public async Task UpdateAsync ( TaxPayer taxPayer )
        {
            string sql = "UPDATE public.TaxPayers SET Identity = @Identity, Address = @Address, NaceCode = @NaceCode, Obligation = @Obligation, Application = @Application WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, taxPayer);
        }
    }
}
