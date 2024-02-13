using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.BLL.Services
{
    public class CompanyServices(ICompanyRepository _companyRepository)
    {
        public Company Add(Company company) { return _companyRepository.Add(company); }
    }
}
