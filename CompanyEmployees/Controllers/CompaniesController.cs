using Microsoft.AspNetCore.Mvc;
using Services.ServiceInterfaces;

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


        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _companySerivce.GetAllCompanies();
            return Ok(companies);
        }
    }
}
