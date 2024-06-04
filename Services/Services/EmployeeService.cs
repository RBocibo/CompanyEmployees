using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Services.ServiceInterfaces;
using Shared;
using Shared.DataTransferObjects;

namespace Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper, ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = repository;
            _mapper = mapper;
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeesDTO> CreateEmployee(CreateEmployeeDTO employee)
        {
            var getCompany = await _companyRepository.GetByIdExpressionAsync(x => x.Id ==  employee.CompanyId);

            if(getCompany == null)
            {
                throw new CompanyNotFoundException(employee.CompanyId);
            }

            employee = new CreateEmployeeDTO(employee.Name, employee.Age, employee.Position, getCompany.Id);

            var mapEmployee = _mapper.Map<Employee>(employee);


            await _employeeRepository.CreateAsync(mapEmployee);
            await _unitOfWork.CommitAsync();

            var employeeToReturn = _mapper.Map<EmployeesDTO>(mapEmployee);

            return employeeToReturn;
        }

        public async Task<IEnumerable<EmployeesDTO>> GetAllEmployeesAsync(CancellationToken cancellationToken)
        {
            var getEmployees = await _employeeRepository.GetAllAsync();
            var mappedEmployees = _mapper.Map<IEnumerable<EmployeesDTO>>(getEmployees);
            return mappedEmployees;
        }

        public async Task<IEnumerable<EmployeesDTO>> GetAllEmployeesByCompanyId(Guid companyId, CancellationToken cancellationToken)
        {
            var getCompany = await _companyRepository.GetByIdExpressionAsync(x => x.Id ==  companyId);

            if(getCompany == null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var getEmployeesByCompanyId = await _employeeRepository.GetByExpressionAsync(x => x.CompanyId == getCompany.Id);

            var mappedEmployees = _mapper.Map<IEnumerable<EmployeesDTO>>(getEmployeesByCompanyId);
            return mappedEmployees;
        }

        public async Task<EmployeesDTO> GetSingleEmployeeForCompany(Guid companyId, Guid employeeId, CancellationToken cancellationToken)
        {
            var getCompany = await _companyRepository.GetByIdExpressionAsync(x => x.Id == companyId);

            if(getCompany == null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var getEmployee = await _employeeRepository.GetByIdExpressionAsync(x => x.CompanyId == getCompany.Id && x.Id == employeeId);

            var mappedEmployee = _mapper.Map<EmployeesDTO>(getEmployee);
            return mappedEmployee;
        }
    }
}
