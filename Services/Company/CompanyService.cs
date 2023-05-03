using ABCDapperWEBAPI.DTOs.Company;
using ABCDapperWEBAPI.Repository.Company;
using Microsoft.IdentityModel.Tokens;

namespace ABCDapperWEBAPI.Services.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task CreateCompany(CompanyCreationDto company)
        {
            await _companyRepository.CreateCompany(company);
        }

        public async Task<IEnumerable<Models.Company>?> GetCompanies()
        {
            var companies = await _companyRepository.GetCompanies();

            if (companies is null)
            {
                return null;
            }

            return companies;
        }

        public async Task<Models.Company?> GetCompany(int Id)
        {
            var company = await _companyRepository.GetCompany(Id);

            if (company is null)
            {
                return null;
            }

            return company;
        }

        public async Task UpdateCompany(int id, CompanyCreationDto company)
        {
            if (String.IsNullOrEmpty(id.ToString()) && company is not null)
            {
                await _companyRepository.UpdateCompany(id, company);
            }
        }
    }
}
