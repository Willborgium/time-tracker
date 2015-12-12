using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using TimeTracker.Core.Model;
using TimeTracker.Core.Repository;
using TimeTracker.Core.Service;
using TimeTracker.Data.Repository;

namespace TimeTracker.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class TimeTrackerService : ITimeTrackerService
    {
        public WebResponse<string> Heartbeat(string message)
        {
            var output = new WebResponse<string>();

            try
            {
                output.Data = $"Okay! ({message})";
            }
            catch(Exception err)
            {
                output.Data = null;

                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse AddPerson(Person person)
        {
            var output = new WebResponse();

            try
            {
                PersonSvc.AddPerson(person);
            }
            catch (Exception err)
            {
                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse<List<Person>> GetPeople()
        {
            var output = new WebResponse<List<Person>>();

            try
            {
                output.Data = PersonSvc.GetPeople().ToList();
            }
            catch (Exception err)
            {
                output.Data = null;

                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        private static IPersonService _personSvc;

        private static IPersonRepository _personRepo;

        private IPersonRepository PersonRepo
        {
            get
            {
                if(_personRepo == null)
                {
                    _personRepo = new EntityPersonRepository();
                }

                return _personRepo;
            }
        }

        private IPersonService PersonSvc
        {
            get
            {
                if(_personSvc == null)
                {
                    _personSvc = new PersonService(PersonRepo);
                }

                return _personSvc;
            }
        }
    }
}