using System.Collections.Generic;
using ATT.Infrastructure.ActionResults;
using ATT.Infrastructure.Exceptions;
using ATT.Infrastructure.Models;

namespace ATT.Infrastructure.EntityFramework.Results
{
    public class EmployeeRepositoryResult : IRepositoryResult
    {
        public bool ActionStatus { get; set; }
        public string ActionMessage { get; set; }
        public TaskTrackerException ActionInnerException { get; set; }
        public IEnumerable<ISecurableObject> RepositoryObjects { get; set; }
    }
}
