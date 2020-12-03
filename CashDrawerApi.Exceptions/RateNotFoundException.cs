using System;
using System.Runtime.Serialization;

namespace CashDrawerApi.Exceptions
{
    public class RateNotFoundException : ApplicationException
    {
        public RateNotFoundException()
        {
            
        }

        public RateNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            
        }

        public RateNotFoundException(string message) : base(message)
        {
            
        }

        public RateNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
