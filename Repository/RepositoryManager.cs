using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_context));
            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(_context));
        }
        public ICompanyRepository CompanyRepository => _companyRepository.Value;

        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
