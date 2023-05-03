using ABCDapperWEBAPI.Models;
using ABCDapperWEBAPI.DTOs.Company;

namespace ABCDapperWEBAPI.Repository.Company
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Models.Company>> GetCompanies();

        Task<Models.Company> GetCompany(int Id);

        Task CreateCompany (CompanyCreationDto company);
        Task UpdateCompany (int id, CompanyCreationDto company);
    }
}
