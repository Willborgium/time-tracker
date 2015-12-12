using System;

namespace TimeTracker.Core.Model
{
    public enum WorkEventType
    {
        WorkFromHome,
        PaidTimeOff
    }

    public class WorkEvent
    {
        public int Id { get; set; }

        public WorkEventType Type { get; set; }

        public DateTime Date { get; set; }

        public decimal Duration { get; set; }

        public string Description { get; set; }
    }
}
