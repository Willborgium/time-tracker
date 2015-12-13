using System.Collections.Generic;
using TimeTracker.Core.Model;

namespace TimeTracker.Core.Service
{
    public interface ICompanyService
    {
        Company GetCompany(int id);

        IEnumerable<Company> GetCompanies();

        void AddCompany(Company company);

        void DeleteCompany(int id);

        void UpdateCompany(Company company);
    }
}