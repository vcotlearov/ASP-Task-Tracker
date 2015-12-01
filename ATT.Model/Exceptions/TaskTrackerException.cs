using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Infrastructure.Exceptions
{
    public class TaskTrackerException : Exception
    {
        public TaskTrackerException()
        {
        }

        public TaskTrackerException(string message) : base(message)
        {
        }

        public TaskTrackerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TaskTrackerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
