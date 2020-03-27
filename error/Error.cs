using System;
using System.Runtime.Serialization;

namespace csjvm.error
{
    public class Error : Exception
    {
        public Error()
        {
        }

        protected Error(SerializationInfo? info, StreamingContext context) : base(info, context)
        {
        }

        public Error(string? message) : base(message)
        {
        }

        public Error(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}