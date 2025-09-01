using System;

namespace schoolapp.Domain.Exceptions
{
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(string message) : base(message)
        {
        }

        public BusinessRuleException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}