using System;

namespace ExceptionsPractice.Exceptions
{
    public class CustomMessageException : Exception
    {
        public CustomMessageException() { }

        public CustomMessageException(string customMessage) : base("I´m overloading the base message. " + customMessage) { }

        public CustomMessageException(string message, Exception inner) : base(message, inner){ }
    }
}
