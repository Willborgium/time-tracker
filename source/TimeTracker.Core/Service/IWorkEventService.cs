using System.Collections.Generic;
using TimeTracker.Core.Model;

namespace TimeTracker.Core.Service
{
    public interface IWorkEventService
    {
        WorkEvent GetWorkEvent(int companyId, int personId, int id);

        IEnumerable<WorkEvent> GetWorkEvents(int companyId, int personId);

        void AddWorkEvent(int companyId, int personId, WorkEvent workEvent);

        void DeleteWorkEvent(int companyId, int personId, int id);

        void UpdateWorkEvent(int companyId, int personId, WorkEvent workEvent);
    }
}