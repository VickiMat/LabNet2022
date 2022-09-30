using System;

namespace Common.Exceptions
{
    public class NotFoundIDException : Exception
    {
        public int IdEnteredNumber { get; private set; }
        public string IdEnteredString { get; private set; }

        public NotFoundIDException(int idEntered) : base("The ID number " + idEntered + " doesn´t exist!")
        {
            IdEnteredNumber = idEntered;
        }
        public NotFoundIDException(string idEntered) : base("The ID " + idEntered + " doesn´t exist!")
        {
            IdEnteredString = idEntered;
        }

    }
}
