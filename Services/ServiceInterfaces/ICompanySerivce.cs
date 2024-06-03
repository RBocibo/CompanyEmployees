

using Shared.DataTransferObjects;

namespace Services.ServiceInterfaces
{
    public interface ICompanySerivce
    {
        Task<List<CompanyDTO>> GetAllCompanies();
        Task<CompanyDTO> GetCompanyById(Guid id);
    }
}
