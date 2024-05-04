
using Contracts;
using Services.ServiceInterfaces;
using Shared.DataTransferObjects;

namespace Services.Services
{
    public class CompanyService : ICompanySerivce
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CompanyDTO>> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllAsync();

            var companyDTOs = companies.Select(x =>
            new CompanyDTO(x.Id, x.Name, string.Join(' ', x.Address, x.Country))).ToList();

            return companyDTOs;
        }
    }
}
