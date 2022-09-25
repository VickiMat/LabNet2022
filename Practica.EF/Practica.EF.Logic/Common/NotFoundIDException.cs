using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic.Common
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
