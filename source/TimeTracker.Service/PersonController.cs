﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using TimeTracker.Core.Model;
using TimeTracker.Core.Repository;
using TimeTracker.Core.Service;
using TimeTracker.Data.Repository;
using TimeTracker.Service.Core.Model;

namespace TimeTracker.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PersonController : IPersonController
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

        public WebResponse<Person> GetPerson(string companyId, string id)
        {
            var output = new WebResponse<Person>();

            try
            {
                output.Data = PersonSvc.GetPerson(int.Parse(companyId), int.Parse(id));
            }
            catch (Exception err)
            {
                output.Data = null;

                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse<List<Person>> GetPeople(string companyId)
        {
            var output = new WebResponse<List<Person>>();

            try
            {
                output.Data = PersonSvc.GetPeople(int.Parse(companyId)).ToList();
            }
            catch (Exception err)
            {
                output.Data = null;

                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse AddPerson(string companyId, Person person)
        {
            var output = new WebResponse();

            try
            {
                PersonSvc.AddPerson(int.Parse(companyId), person);
            }
            catch (Exception err)
            {
                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse DeletePerson(string companyId, string id)
        {
            var output = new WebResponse();

            try
            {
                PersonSvc.DeletePerson(int.Parse(companyId), int.Parse(id));
            }
            catch (Exception err)
            {
                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse UpdatePerson(string companyId, Person person)
        {
            var output = new WebResponse();

            try
            {
                PersonSvc.UpdatePerson(int.Parse(companyId), person);
            }
            catch (Exception err)
            {
                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

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

        private static IPersonRepository _personRepo;

        private static IPersonService _personSvc;
    }
}