
using Contracts;
using Services.ServiceInterfaces;

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

        public async Task<List<Entities.Company>> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllAsync();
            _unitOfWork.Commit();

            return companies;
        }
    }
}
