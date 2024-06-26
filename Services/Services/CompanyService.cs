﻿
using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Services.ServiceInterfaces;
using Shared.DataTransferObjects;

namespace Services.Services
{
    public class CompanyService : ICompanySerivce
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CompanyDTO> CreateCompany(CreateCompanyDTO company)
        {
            company = new CreateCompanyDTO(company.Name, company.Address, company.Country);

            var mappedCompany = _mapper.Map<Company>(company);
            await _companyRepository.CreateAsync(mappedCompany);
            await _unitOfWork.CommitAsync();

            var companyToReturn = _mapper.Map<CompanyDTO>(mappedCompany);
            return companyToReturn;
        }

        public async Task<List<CompanyDTO>> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllAsync();

            var companyDTOs = _mapper.Map<IEnumerable<CompanyDTO>>(companies);

            return (List<CompanyDTO>)companyDTOs;
        }

        public async Task<CompanyDTO> GetCompanyById(Guid id)
        {
            var company = await _companyRepository.GetByIdExpressionAsync(x => x.Id == id);

            if (company is null)
            {
                throw new CompanyNotFoundException(id);
            }

            var companyDTO = _mapper.Map<CompanyDTO>(company);
            return companyDTO;
        }
    }
}
