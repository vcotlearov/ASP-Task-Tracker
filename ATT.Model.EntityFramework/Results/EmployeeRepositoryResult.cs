using System.Collections.Generic;
using ATT.Infrastructure.ActionResults;
using ATT.Infrastructure.Exceptions;
using ATT.Infrastructure.Models;

namespace ATT.Infrastructure.EntityFramework.Results
{
    public class EmployeeRepositoryResult : IRepositoryResult
    {
        public bool ActionStatus { get; }
        public string ActionMessage { get; }
        public TaskTrackerException ActionInnerException { get; }
        public IEnumerable<ISecurableObject> RepositoryObjects { get; }

        public EmployeeRepositoryResult()
        {
            ActionMessage = string.Empty;
            ActionInnerException = null;
            RepositoryObjects = null;
        }

        public EmployeeRepositoryResult(IEnumerable<ISecurableObject> repositoryObjects): this()
        {
            ActionStatus = true;
            RepositoryObjects = repositoryObjects;
        }

        public EmployeeRepositoryResult(string message, TaskTrackerException exception) : this()
        {
            ActionStatus = false;
            ActionMessage = message;
            ActionInnerException = exception;
        }
    }
}
