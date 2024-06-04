using Shared;
using Shared.DataTransferObjects;

namespace Services.ServiceInterfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeesDTO>> GetAllEmployeesAsync(CancellationToken cancellationToken);
        Task<IEnumerable<EmployeesDTO>> GetAllEmployeesByCompanyId(Guid companyId, CancellationToken cancellationToken);
        Task<EmployeesDTO> GetSingleEmployeeForCompany(Guid companyId, Guid employeeId, CancellationToken cancellationToken);
        Task<EmployeesDTO> CreateEmployee(CreateEmployeeDTO createEmployee);
        Task DeleteEmployee(Guid companyId, Guid employeeId);
    }
}
