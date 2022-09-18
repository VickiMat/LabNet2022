using ExceptionsPractice.Exceptions;
using ExceptionsPractice.Models;
using System;

namespace ExceptionsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chosenExercise;

            Console.WriteLine("Welcome to the practical exercise of exceptions, extension methods and unit test");
            do
            {
                Console.WriteLine("Please select which exercise do you want to see: \n1-Division by zero.\n2-General division.\n3-Custom method." +
                "\n4-Custom method and custom exception\n5-Exit");
                chosenExercise = int.Parse(Console.ReadLine());
                {
                    switch (chosenExercise)
                    {
                        case 1:
                            ZeroDivisor.Division();
                            break;
                        case 2:
                            GeneralDivision.Division();
                            break;
                        case 3:
                            Exercise3();
                            break;
                        case 4:
                            Exercise4();
                            break;
                    }
                }
            }
            while (chosenExercise != 5);

        }
        private static void Exercise3()
        {
            try { Logic.FirstMethod(); }
            catch (Exception ex)
            {
                Console.WriteLine($"You obtain an exception of the type {ex.GetType()} \nand the message is \"{ex.Message}\" \n");
            }
            finally { Console.WriteLine("Here ends the exercise number 3\n"); }
        }

        private static void Exercise4()
        {
            try { Logic.ThrowMyException(); }
            catch (CustomMessageException mex)
            {
                Console.WriteLine($"You obtain an exception of the type {mex.GetType()} \nand the message is \"{mex.Message}\" \n");
            }
            finally { Console.WriteLine("Here ends the exercise number 4\n"); }
        }
    }
}
