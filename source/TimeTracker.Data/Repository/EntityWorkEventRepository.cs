using System;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Core.Repository;

namespace TimeTracker.Data.Repository
{
    public class EntityWorkEventRepository : IWorkEventRepository
    {
        public Core.Model.WorkEvent GetWorkEvent(int companyId, int personId, int id)
        {
            Core.Model.WorkEvent output = null;

            using (var entity = new TimeTrackerEntities())
            {
                var dbWorkEvent = entity.WorkEvents.FirstOrDefault(we => we.PersonId == personId &&
                                                                         we.Person.CompanyId == companyId &&
                                                                         we.Id == id);

                if (dbWorkEvent == null)
                {
                    throw new Exception($"Cannot find work event with ID {id}.");
                }

                output = new Core.Model.WorkEvent
                {
                    Id = dbWorkEvent.Id,
                    Date = dbWorkEvent.Date,
                    Description = dbWorkEvent.Description,
                    Duration = dbWorkEvent.Duration,
                    Type = (Core.Model.WorkEventType)dbWorkEvent.Type
                };
            }

            return output;
        }

        public IEnumerable<Core.Model.WorkEvent> GetWorkEvents(int companyId, int personId)
        {
            IEnumerable<Core.Model.WorkEvent> output = null;

            using (var entity = new TimeTrackerEntities())
            {
                output = entity.WorkEvents.Where(we => we.PersonId == personId &&
                                                       we.Person.CompanyId == companyId)
                                          .Select(we => new Core.Model.WorkEvent
                                          {
                                              Id = we.Id,
                                              Date = we.Date,
                                              Description = we.Description,
                                              Duration = we.Duration,
                                              Type = (Core.Model.WorkEventType)we.Type
                                          })
                                          .ToList();
            }

            return output;
        }

        public void AddWorkEvent(int companyId, int personId, Core.Model.WorkEvent workEvent)
        {

            using (var entity = new TimeTrackerEntities())
            {
                var dbPerson = entity.People.FirstOrDefault(p => p.Id == personId && p.CompanyId == companyId);

                if(dbPerson == null)
                {
                    throw new Exception($"Cannot find person with ID {personId}.");
                }

                var dbWorkEvent = new WorkEvent
                {
                    Person = dbPerson,
                    Date = workEvent.Date,
                    Description = workEvent.Description,
                    Duration = workEvent.Duration,
                    Type = (int)workEvent.Type
                };

                entity.WorkEvents.Add(dbWorkEvent);

                entity.SaveChanges();
            }
        }

        public void DeleteWorkEvent(int companyId, int personId, int id)
        {
            using (var entity = new TimeTrackerEntities())
            {
                var dbWorkEvent = entity.WorkEvents.FirstOrDefault(we => we.PersonId == personId &&
                                                                         we.Person.CompanyId == companyId &&
                                                                         we.Id == id);

                if (dbWorkEvent == null)
                {
                    throw new Exception($"Cannot find work event with ID {id}.");
                }

                entity.WorkEvents.Remove(dbWorkEvent);

                entity.SaveChanges();
            }
        }

        public void UpdateWorkEvent(int companyId, int personId, Core.Model.WorkEvent workEvent)
        {
            using (var entity = new TimeTrackerEntities())
            {
                var dbWorkEvent = entity.WorkEvents.FirstOrDefault(we => we.PersonId == personId &&
                                                                         we.Person.CompanyId == companyId &&
                                                                         we.Id == workEvent.Id);

                if (dbWorkEvent == null)
                {
                    throw new Exception($"Cannot find work event with ID {workEvent.Id}.");
                }

                dbWorkEvent.Date = workEvent.Date;

                dbWorkEvent.Description = workEvent.Description;

                dbWorkEvent.Duration = workEvent.Duration;

                dbWorkEvent.Type = (int)workEvent.Type;

                entity.SaveChanges();
            }
        }
    }
}