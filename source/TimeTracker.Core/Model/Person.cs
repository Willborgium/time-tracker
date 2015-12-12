using System.Collections.Generic;

namespace TimeTracker.Core.Model
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<WorkEvent> WorkEvents { get; set; }

        public Person()
        {
            WorkEvents = new List<WorkEvent>();
        }
    }
}