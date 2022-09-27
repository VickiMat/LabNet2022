using System;

namespace Common.Exceptions
{
    public class NotFoundIDException : Exception
    {
        public int IdEntered { get; private set; }

        public NotFoundIDException(int idEntered) : base("The ID number " + idEntered + " doesn´t exist!")
        {
            IdEntered = idEntered;
        }

    }
}
