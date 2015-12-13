using System;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Core.Repository;

namespace TimeTracker.Data.Repository
{
    public class EntityCompanyRepository : ICompanyRepository
    {
        public Core.Model.Company GetCompany(int id)
        {
            Core.Model.Company output = null;

            using (var entity = new TimeTrackerEntities())
            {
                var dbCompany = entity.Companies.FirstOrDefault(c => c.Id == id);

                if(dbCompany == null)
                {
                    throw new Exception($"Cannot find company with ID {id}.");
                }

                output = new Core.Model.Company
                {
                    Id = dbCompany.Id,
                    Name = dbCompany.Name
                };
            }

            return output;
        }

        public IEnumerable<Core.Model.Company> GetCompanies()
        {
            IEnumerable<Core.Model.Company> output = null;

            using (var entity = new TimeTrackerEntities())
            {
                output = entity.Companies.Select(c => new Core.Model.Company
                         {
                             Id = c.Id,
                             Name = c.Name
                         }).ToList();
            }

            return output;
        }

        public void AddCompany(Core.Model.Company company)
        {
            var dbCompany = new Company
            {
                Name = company.Name
            };

            using (var entity = new TimeTrackerEntities())
            {
                entity.Companies.Add(dbCompany);

                entity.SaveChanges();
            }
        }

        public void DeleteCompany(int id)
        {
            using (var entity = new TimeTrackerEntities())
            {
                var dbCompany = entity.Companies.FirstOrDefault(c => c.Id == id);

                if (dbCompany == null)
                {
                    throw new Exception($"Cannot find company with ID {id}.");
                }

                entity.Companies.Remove(dbCompany);

                entity.SaveChanges();
            }
        }

        public void UpdateCompany(Core.Model.Company company)
        {
            using (var entity = new TimeTrackerEntities())
            {
                var dbCompany = entity.Companies.FirstOrDefault(c => c.Id == company.Id);

                if (dbCompany == null)
                {
                    throw new Exception($"Cannot find company with ID {company.Id}.");
                }

                dbCompany.Name = company.Name;

                entity.SaveChanges();
            }
        }
    }
}