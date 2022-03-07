using System;
using System.Runtime.Serialization;

namespace CookBook.Mobile.Exceptions
{
    public class ViewNotLocatedException : Exception
    {
        public ViewNotLocatedException()
        {
        }

        public ViewNotLocatedException(string message) : base(message)
        {
        }

        public ViewNotLocatedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ViewNotLocatedException(SerializationInfo info, StreamingContext ctx) : base(info, ctx)
        {
        }
    }
}