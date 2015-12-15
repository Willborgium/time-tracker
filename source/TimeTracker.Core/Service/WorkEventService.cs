using System.Collections.Generic;
using TimeTracker.Core.Model;
using TimeTracker.Core.Repository;

namespace TimeTracker.Core.Service
{
    public class WorkEventService : IWorkEventService
    {
        public WorkEventService(IWorkEventRepository repository)
        {
            if(_repository == null)
            {
                _repository = repository;
            }
        }

        public WorkEvent GetWorkEvent(int companyId, int personId, int id)
        {
            return _repository.GetWorkEvent(companyId, personId, id);
        }

        public IEnumerable<WorkEvent> GetWorkEvents(int companyId, int personId)
        {
            return _repository.GetWorkEvents(companyId, personId);
        }

        public void AddWorkEvent(int companyId, int personId, WorkEvent workEvent)
        {
            _repository.AddWorkEvent(companyId, personId, workEvent);
        }

        public void DeleteWorkEvent(int companyId, int personId, int id)
        {
            _repository.DeleteWorkEvent(companyId, personId, id);
        }

        public void UpdateWorkEvent(int companyId, int personId, WorkEvent workEvent)
        {
            _repository.UpdateWorkEvent(companyId, personId, workEvent);
        }

        private static IWorkEventRepository _repository;
    }
}