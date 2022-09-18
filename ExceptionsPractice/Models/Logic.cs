using ExceptionsPractice.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsPractice.Models
{
    public class Logic
    {

        public static void FirstMethod()
        {
            string[] favoriteFruits = { "Orange", "Banana", "Pear" };

            Console.WriteLine(favoriteFruits[3]);
        }

        public static void ThrowMyException()
        {
            throw new MyException("Probando mesaje");
        }
    }
}
