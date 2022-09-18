using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsPractice.Exceptions
{
    public class MyException : Exception
    {
        public MyException() { }

        public MyException(string customMessage) : base(customMessage)
        {
            customMessage = "FNSDLFNL" + customMessage + base.Message;
        }

        public MyException(string message, Exception inner) : base(message, inner){ }
    }
}
