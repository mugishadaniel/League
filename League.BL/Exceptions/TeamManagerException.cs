using System.Runtime.Serialization;

namespace League.BL.Exceptions
{
    [Serializable]
    internal class TeamManagerException : Exception
    {
        public TeamManagerException()
        {
        }

        public TeamManagerException(string? message) : base(message)
        {
        }

        public TeamManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TeamManagerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}