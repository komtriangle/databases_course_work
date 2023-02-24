using System.Runtime.Serialization;

namespace FilmsApp.WebApi.Exceptions
{
	public class FilmsException: ApplicationException
    {
        public FilmsException() { }

        public FilmsException(string message) : base(message) { }

        public FilmsException(string message, Exception inner) : base(message, inner) { }

        protected FilmsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
