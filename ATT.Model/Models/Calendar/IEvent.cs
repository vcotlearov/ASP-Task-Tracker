using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using ATT.Infrastructure.Models.Employee;

namespace ATT.Infrastructure.Models.Calendar
{
    public interface IEvent : ISecurableObject
    {
        ICalendar Calendar { get; }

        string EventTitle { get; }
        string EventPlace { get; }
        DateTime EventStartDate { get; }
        DateTime EventEndDate { get; }

        string EventDescription { get; }
        IEnumerable<IAccount> EventParticipants { get; }

    }
}