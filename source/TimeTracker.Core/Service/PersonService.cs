using System;
using System.Collections.Generic;
using TimeTracker.Core.Model;
using TimeTracker.Core.Repository;

namespace TimeTracker.Core.Service
{
    public class PersonService : IPersonService
    {
        public PersonService(IPersonRepository repository)
        {
            if(_repository == null)
            {
                _repository = repository;
            }
        }

        public Person GetPerson(int companyId, int id)
        {
            return _repository.GetPerson(companyId, id);
        }

        public IEnumerable<Person> GetPeople(int companyId)
        {
            return _repository.GetPeople(companyId);
        }

        public void AddPerson(int companyId, Person person)
        {
            _repository.AddPerson(companyId, person);
        }

        public void DeletePerson(int companyId, int id)
        {
            _repository.DeletePerson(companyId, id);
        }

        public void UpdatePerson(int companyId, Person person)
        {
            _repository.UpdatePerson(companyId, person);
        }

        private static IPersonRepository _repository;
    }
}