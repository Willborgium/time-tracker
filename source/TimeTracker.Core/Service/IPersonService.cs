using System.Collections.Generic;
using TimeTracker.Core.Model;

namespace TimeTracker.Core.Service
{
    public interface IPersonService
    {
        void AddPerson(Person person);

        IEnumerable<Person> GetPeople();
    }
}