using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceInterfaces;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanySerivce _companySerivce;
        public CompaniesController(ICompanySerivce companySerivce)
        {
            _companySerivce = companySerivce;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            //throw new Exception("Exception");
            var companies = await _companySerivce.GetAllCompanies();
            return Ok(companies);
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new CompanyNotFoundException(id);
            }
            var company = await _companySerivce.GetCompanyById(id);
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany([FromBody] CreateCompanyDTO createCompanyDTO)
        {
            var createCompany = await _companySerivce.CreateCompany(createCompanyDTO);
            return Ok(createCompany);

        }
    }
}
