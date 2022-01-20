using System.Runtime.Serialization;

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
