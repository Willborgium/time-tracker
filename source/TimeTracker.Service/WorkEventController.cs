using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using TimeTracker.Core.Model;
using TimeTracker.Core.Repository;
using TimeTracker.Core.Service;
using TimeTracker.Data.Repository;
using TimeTracker.Service.Core.Model;
using TimeTracker.Service.Core.Service;

namespace TimeTracker.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class WorkEventController : IWorkEventController
    {
        public WebResponse<string> Heartbeat(string message)
        {
            var output = new WebResponse<string>();

            try
            {
                output.Data = $"Okay! ({message})";
            }
            catch (Exception err)
            {
                output.Data = null;

                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse<WorkEvent> GetWorkEvent(string companyId, string personId, string id)
        {
            var output = new WebResponse<WorkEvent>();

            try
            {
                output.Data = WorkEventSvc.GetWorkEvent(int.Parse(companyId), int.Parse(personId), int.Parse(id));
            }
            catch (Exception err)
            {
                output.Data = null;

                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse<List<WorkEvent>> GetWorkEvents(string companyId, string personId)
        {
            var output = new WebResponse<List<WorkEvent>>();

            try
            {
                output.Data = WorkEventSvc.GetWorkEvents(int.Parse(companyId), int.Parse(personId)).ToList();
            }
            catch (Exception err)
            {
                output.Data = null;

                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse AddWorkEvent(string companyId, string personId, WorkEvent person)
        {
            var output = new WebResponse();

            try
            {
                WorkEventSvc.AddWorkEvent(int.Parse(companyId), int.Parse(personId), person);
            }
            catch (Exception err)
            {
                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse DeleteWorkEvent(string companyId, string personId, string id)
        {
            var output = new WebResponse();

            try
            {
                WorkEventSvc.DeleteWorkEvent(int.Parse(companyId), int.Parse(personId), int.Parse(id));
            }
            catch (Exception err)
            {
                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse UpdateWorkEvent(string companyId, string personId, WorkEvent person)
        {
            var output = new WebResponse();

            try
            {
                WorkEventSvc.UpdateWorkEvent(int.Parse(companyId), int.Parse(personId), person);
            }
            catch (Exception err)
            {
                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        private IWorkEventRepository WorkEventRepo
        {
            get
            {
                if (_workEventRepo == null)
                {
                    _workEventRepo = new EntityWorkEventRepository();
                }

                return _workEventRepo;
            }
        }

        private IWorkEventService WorkEventSvc
        {
            get
            {
                if (_workEventService == null)
                {
                    _workEventService = new WorkEventService(WorkEventRepo);
                }

                return _workEventService;
            }
        }

        private static IWorkEventRepository _workEventRepo;

        private static IWorkEventService _workEventService;
    }
}