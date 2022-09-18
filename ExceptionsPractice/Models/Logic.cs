using ExceptionsPractice.Exceptions;
using ExceptionsPractice.ExtensionMethods;
using System;
using System.Collections.Generic;

namespace ExceptionsPractice.Models
{
    public class Logic
    {
        public static void FirstMethod()
        {
            List<string> fruits = new List<string>() { "Orange", "Banana", "Pear" };
            fruits.AddBestFruit();
            Console.WriteLine(fruits[4]);
        }

        public static void ThrowMyException()
        {
            throw new CustomMessageException("Hi this is the personalized message.");
        }
    }
}
