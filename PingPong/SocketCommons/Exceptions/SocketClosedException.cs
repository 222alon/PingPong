using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SocketCommons.Exceptions
{
    public class SocketClosedException : Exception
    {
        public SocketClosedException()
        {
        }

        public SocketClosedException(string? message) : base(message)
        {
        }

        public SocketClosedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SocketClosedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
