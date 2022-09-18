using ExceptionsPractice.Exceptions;
using ExceptionsPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("Please select with exercise do you want to see: \n1-Division by zero.\n2-General division.\n3-Custom method." +
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
                            try { Logic.FirstMethod(); }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"You obtain an exception of the type {ex.GetType()} and the message is \"{ex.Message}\" \n");
                            }
                            break;
                        case 4:
                            try { Logic.ThrowMyException(); }
                            catch (MyException mex)
                            {
                                Console.WriteLine($"You obtain an exception of the type {mex.GetType()} and the message is \"{mex.Message}\" \n");
                            }
                            break;
                    }
                }
            }
            while (chosenExercise != 5);

            


        }
    }
}
