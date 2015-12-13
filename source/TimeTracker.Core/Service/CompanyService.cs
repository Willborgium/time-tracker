using System.Collections.Generic;
using TimeTracker.Core.Model;
using TimeTracker.Core.Repository;

namespace TimeTracker.Core.Service
{
    public class CompanyService : ICompanyService
    {
        public CompanyService(ICompanyRepository repository)
        {
            if (_repository == null)
            {
                _repository = repository;
            }
        }

        public Company GetCompany(int id)
        {
            return _repository.GetCompany(id);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _repository.GetCompanies();
        }

        public void AddCompany(Company company)
        {
             _repository.AddCompany(company);
        }

        public void DeleteCompany(int id)
        {
            _repository.DeleteCompany(id);
        }

        public void UpdateCompany(Company company)
        {
            _repository.UpdateCompany(company);
        }

        private static ICompanyRepository _repository;
    }
}