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

        public WorkEvent GetWorkEvent(int personId, int id)
        {
            return _repository.GetWorkEvent(personId, id);
        }

        public IEnumerable<WorkEvent> GetWorkEvents(int personId)
        {
            return _repository.GetWorkEvents(personId);
        }

        public void AddWorkEvent(int personId, WorkEvent workEvent)
        {
            _repository.AddWorkEvent(personId, workEvent);
        }

        public void DeleteWorkEvent(int personId, int id)
        {
            _repository.DeleteWorkEvent(personId, id);
        }

        public void UpdateWorkEvent(int personId, WorkEvent workEvent)
        {
            _repository.UpdateWorkEvent(personId, workEvent);
        }

        private static IWorkEventRepository _repository;
    }
}