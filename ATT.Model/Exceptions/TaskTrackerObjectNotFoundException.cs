using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Infrastructure.Exceptions
{
    public class TaskTrackerObjectNotFoundException : TaskTrackerException
    {
        public TaskTrackerObjectNotFoundException()
        {
        }

        public TaskTrackerObjectNotFoundException(string message) : base(message)
        {
        }

        public TaskTrackerObjectNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TaskTrackerObjectNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
