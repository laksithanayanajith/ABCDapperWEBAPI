using ABCDapperWEBAPI.Data;
using ABCDapperWEBAPI.DTOs.Company;
using Dapper;
using System.Collections.Generic;

namespace ABCDapperWEBAPI.Repository.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task CreateCompany(CompanyCreationDto company)
        {
            var quearyNewCompany = "INSERT INTO Company(Name, Address, Country) VALUES (@Name, @Address, @Country)";

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("Name", company.Name, System.Data.DbType.String);
            dynamicParameters.Add("Address", company.Address, System.Data.DbType.String);
            dynamicParameters.Add("Country", company.Country, System.Data.DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(quearyNewCompany, dynamicParameters);
            }
        }

        public async Task<IEnumerable<Models.Company>> GetCompanies()
        {
            var quearyCompanies = "SELECT * FROM company";

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Models.Company>(quearyCompanies);

                return companies.ToList();
            }
        }

        public async Task<Models.Company> GetCompany(int Id)
        {
            var quearyCompany = "SELECT * FROM company WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Models.Company>(quearyCompany, new { Id });

                return company;
            }
        }

        public async Task UpdateCompany(int id, CompanyCreationDto company)
        {
            var quearyUpdateCompany = "UPDATE Company SET Name = @Name, Address = @Address, Country = @Country WHERE Id = @Id";

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("Id", id, System.Data.DbType.Int64);
            dynamicParameters.Add("Address", company.Address, System.Data.DbType.String);
            dynamicParameters.Add("Country", company.Country, System.Data.DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(quearyUpdateCompany, dynamicParameters);
            }
        }
    }
}
