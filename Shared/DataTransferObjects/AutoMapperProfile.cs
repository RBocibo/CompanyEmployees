using AutoMapper;
using Entities;
using Shared;
using Shared.DataTransferObjects;

namespace CompanyEmployees
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Company, CompanyDTO>()
                .ForCtorParam("fullAddress", opt => opt
                .MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Employee, EmployeesDTO>();
            CreateMap<CreateCompanyDTO, Company>();
            CreateMap<CreateEmployeeDTO, Employee>();
        }
    }
}
