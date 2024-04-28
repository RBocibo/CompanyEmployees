

using Contracts;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Entities.Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
