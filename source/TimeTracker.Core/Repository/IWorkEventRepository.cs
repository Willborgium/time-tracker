using System.Collections.Generic;
using TimeTracker.Core.Model;

namespace TimeTracker.Core.Repository
{
    public interface IWorkEventRepository
    {
        WorkEvent GetWorkEvent(int companyId, int personId, int id);

        IEnumerable<WorkEvent> GetWorkEvents(int companyId, int personId);

        void AddWorkEvent(int companyId, int personId, WorkEvent workEvent);

        void DeleteWorkEvent(int companyId, int personId, int id);

        void UpdateWorkEvent(int companyId, int personId, WorkEvent workEvent);
    }
}