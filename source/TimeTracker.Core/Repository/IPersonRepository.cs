using System.Collections.Generic;
using TimeTracker.Core.Model;

namespace TimeTracker.Core.Repository
{
    public interface IPersonRepository
    {
        void AddPerson(Person person);

        IEnumerable<Person> GetPeople();
    }
}