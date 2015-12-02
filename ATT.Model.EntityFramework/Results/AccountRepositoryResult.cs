using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATT.Infrastructure.ActionResults;
using ATT.Infrastructure.Exceptions;
using ATT.Infrastructure.Models;

namespace ATT.Infrastructure.EntityFramework.Results
{
    public class AccountRepositoryResult : IRepositoryResult
    {
        public bool ActionStatus { get; }
        public string ActionMessage { get; }
        public TaskTrackerException ActionInnerException { get; }
        public IEnumerable<ISecurableObject> RepositoryObjects { get; }

        public AccountRepositoryResult()
        {
            ActionMessage = string.Empty;
            ActionInnerException = null;
            RepositoryObjects = null;
        }

        public AccountRepositoryResult(IEnumerable<ISecurableObject> repositoryObjects) : this()
        {
            ActionStatus = true;
            RepositoryObjects = repositoryObjects;
        }

        public AccountRepositoryResult(string message, TaskTrackerException exception) : this()
        {
            ActionStatus = false;
            ActionMessage = message;
            ActionInnerException = exception;
        }
    }
}
