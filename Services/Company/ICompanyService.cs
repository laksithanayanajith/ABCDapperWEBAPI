using ABCDapperWEBAPI.DTOs.Company;

namespace ABCDapperWEBAPI.Services.Company
{
    public interface ICompanyService
    {
        Task<IEnumerable<Models.Company>?> GetCompanies();

        Task<Models.Company?> GetCompany(int Id);

        Task CreateCompany(CompanyCreationDto company);
        Task UpdateCompany(int id, CompanyCreationDto company);
    }
}
