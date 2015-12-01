using System;
using System.Collections.Generic;
using ATT.Infrastructure.Exceptions;
using ATT.Infrastructure.Models;

namespace ATT.Infrastructure.ActionResults
{
    public interface IResult
    {
        bool ActionStatus { get; }
        string ActionMessage { get; }
        TaskTrackerException ActionInnerException { get; }

        //IEnumerable<ISecurableObject> ActionResult { get; }
    }
}