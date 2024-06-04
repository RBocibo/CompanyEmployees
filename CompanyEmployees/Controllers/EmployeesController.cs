using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceInterfaces;
using Shared;

namespace CompanyEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync(CancellationToken.None);

            return Ok(employees);
        }

        [HttpGet("{companyId:Guid}")]
        public async Task<IActionResult> GetAllEmployeesByCompanyId(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new CompanyNotFoundException(companyId);
            }
            var employees = await _employeeService.GetAllEmployeesByCompanyId(companyId, CancellationToken.None);
            return Ok(employees);
        }

        [HttpGet("{companyId}/{employeeId}")]
        public async Task<IActionResult> GetEmployeeForComapny(Guid companyId, Guid employeeId)
        {
            if (companyId == Guid.Empty)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var employee = await _employeeService.GetSingleEmployeeForCompany(companyId, employeeId, CancellationToken.None);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDTO createEmployee)
        {
            var employee = await _employeeService.CreateEmployee(createEmployee);
            
            return StatusCode(StatusCodes.Status201Created, employee);
        }
    }
}
