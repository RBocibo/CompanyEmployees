

namespace Services.ServiceInterfaces
{
    public interface ICompanySerivce
    {
        Task<List<Entities.Company>> GetAllCompanies();
    }
}
