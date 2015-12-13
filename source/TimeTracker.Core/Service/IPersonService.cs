using System.Collections.Generic;
using TimeTracker.Core.Model;

namespace TimeTracker.Core.Service
{
    public interface IPersonService
    {
        Person GetPerson(int companyId, int id);

        IEnumerable<Person> GetPeople(int companyId);

        void AddPerson(int companyId, Person person);

        void DeletePerson(int companyId, int id);

        void UpdatePerson(int companyId, Person person);
    }
}