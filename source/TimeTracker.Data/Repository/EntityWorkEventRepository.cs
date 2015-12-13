using System;
using System.Collections.Generic;
using TimeTracker.Core.Repository;

namespace TimeTracker.Data.Repository
{
    public class EntityWorkEventRepository : IWorkEventRepository
    {
        public Core.Model.WorkEvent GetWorkEvent(int personId, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Model.WorkEvent> GetWorkEvents(int personId)
        {
            throw new NotImplementedException();
        }

        public void AddWorkEvent(int personId, Core.Model.WorkEvent workEvent)
        {
            throw new NotImplementedException();
        }

        public void DeleteWorkEvent(int personId, int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateWorkEvent(int personId, Core.Model.WorkEvent workEvent)
        {
            throw new NotImplementedException();
        }
    }
}