using System.Collections.Generic;
using TimeTracker.Core.Model;

namespace TimeTracker.Core.Service
{
    public interface IWorkEventService
    {
        WorkEvent GetWorkEvent(int personId, int id);

        IEnumerable<WorkEvent> GetWorkEvents(int personId);

        void AddWorkEvent(int personId, WorkEvent workEvent);

        void DeleteWorkEvent(int personId, int id);

        void UpdateWorkEvent(int personId, WorkEvent workEvent);
    }
}