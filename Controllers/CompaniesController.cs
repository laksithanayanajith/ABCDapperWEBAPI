using ABCDapperWEBAPI.DTOs.Company;
using ABCDapperWEBAPI.Models;
using ABCDapperWEBAPI.Services.Company;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABCDapperWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly CompanyService _companyService;

        public CompaniesController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetCompanies()
        {
            var companies = await _companyService.GetCompanies();

            if (companies is null)
            {
                return NotFound();
            }

            return Ok(companies);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Company>> GetCompany(int Id)
        {
            var company = await _companyService.GetCompany(Id);

            if (company is null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> CreateCompany([FromBody] CompanyCreationDto companyCreationDto)
        {
            await _companyService.CreateCompany(companyCreationDto);

            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Company>> UpdateCompany(int Id, [FromBody] CompanyCreationDto companyCreationDto)
        {
            if (!(String.IsNullOrEmpty(Id.ToString())) && (companyCreationDto is not null))
            {
                if (await _companyService.GetCompany(Id) is not null)
                {
                    await _companyService.UpdateCompany(Id, companyCreationDto);

                    return Ok();
                }
                
            }

            return NotFound();

        }
    }
}
