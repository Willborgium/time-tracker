using System.Collections.Generic;
using TimeTracker.Core.Model;
using TimeTracker.Core.Repository;

namespace TimeTracker.Core.Service
{
    public class PersonService : IPersonService
    {
        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public void AddPerson(Person person)
        {
            _repository.AddPerson(person);
        }

        public IEnumerable<Person> GetPeople()
        {
            return _repository.GetPeople();
        }

        private static IPersonRepository _repository;
    }
}