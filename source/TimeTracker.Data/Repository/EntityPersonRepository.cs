using System;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Core.Repository;

namespace TimeTracker.Data.Repository
{
    public class EntityPersonRepository : IPersonRepository
    {
        public Core.Model.Person GetPerson(int companyId, int id)
        {
            Core.Model.Person output = null;

            using (var entity = new TimeTrackerEntities())
            {
                var dbPerson = entity.People.FirstOrDefault(p => p.Id == id &&
                                                                 p.CompanyId == companyId);

                if(dbPerson == null)
                {
                    throw new Exception($"Cannot find a person with ID {id}.");
                }

                output = new Core.Model.Person
                {
                    Id = dbPerson.Id,
                    FirstName = dbPerson.FirstName,
                    LastName = dbPerson.LastName
                };
            }

            return output;
        }

        public IEnumerable<Core.Model.Person> GetPeople(int companyId)
        {
            IEnumerable<Core.Model.Person> output = null;

            using (var entity = new TimeTrackerEntities())
            {
                output = entity.People.Where(p => p.CompanyId == companyId)
                               .Select(p => new Core.Model.Person
                               {
                                   Id = p.Id,
                                   FirstName = p.FirstName,
                                   LastName = p.LastName
                               })
                               .ToList();
            }

            return output;
        }

        public void AddPerson(int companyId, Core.Model.Person person)
        {
            var dbPerson = new Person
            {
                CompanyId = companyId,
                FirstName = person.FirstName,
                LastName = person.LastName
            };

            using (var entity = new TimeTrackerEntities())
            {
                entity.People.Add(dbPerson);

                entity.SaveChanges();
            }
        }

        public void DeletePerson(int companyId, int id)
        {
            using (var entity = new TimeTrackerEntities())
            {
                var dbPerson = entity.People.FirstOrDefault(p => p.Id == id);

                if (dbPerson == null)
                {
                    throw new Exception($"Cannot find a person with ID {id}.");
                }

                entity.People.Remove(dbPerson);

                entity.SaveChanges();
            }
        }

        public void UpdatePerson(int companyId, Core.Model.Person person)
        {
            using (var entity = new TimeTrackerEntities())
            {
                var dbPerson = entity.People.FirstOrDefault(p => p.Id == person.Id &&
                                                                 p.CompanyId == companyId);

                if (dbPerson == null)
                {
                    throw new Exception($"Cannot find a person with ID {person.Id}.");
                }

                dbPerson.FirstName = person.FirstName;

                dbPerson.LastName = person.LastName;

                entity.SaveChanges();
            }
        }
    }
}