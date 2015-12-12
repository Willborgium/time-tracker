using System.Collections.Generic;
using TimeTracker.Core.Repository;

namespace TimeTracker.Data.Repository
{
    public class EntityPersonRepository : IPersonRepository
    {
        public void AddPerson(Core.Model.Person person)
        {
            var dbPerson = new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName
            };

            using (var entity = new TimeTrackerEntities())
            {
                entity.People.Add(dbPerson);

                entity.SaveChanges();
            }
        }

        public IEnumerable<Core.Model.Person> GetPeople()
        {
            var output = new List<Core.Model.Person>();

            using (var entity = new TimeTrackerEntities())
            {
                foreach(var dbPerson in entity.People)
                {
                    output.Add(new Core.Model.Person
                    {
                        Id = dbPerson.Id,
                        FirstName = dbPerson.FirstName,
                        LastName = dbPerson.LastName
                    });
                }
            }

            return output;
        }
    }
}