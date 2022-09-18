using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsPractice.Models
{
    public class GeneralDivision
    {
        public static void Division(/*decimal Number1, decimal Number2*/)
        { 
            try
            {
                Console.WriteLine("Please insert two numbers to do the division");
                Console.WriteLine("Number 1:");
                decimal Number1 = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Number 2:");
                decimal Number2 = decimal.Parse(Console.ReadLine());
                //GeneralDivision.Division(number1, number2);
                decimal result = Number1 / Number2;
                Console.WriteLine($"The result of the division is: {result} \n");
            }
            catch(DivideByZeroException dex)
            {
                Console.WriteLine("It´s seen like you are trying to divide by zero. Unluckily YOU SHALL NOT PASS!\n" +
                    $"The exception message is: \"{dex.Message}\"\n");
            }
            catch(FormatException fex)
            {
                Console.WriteLine("It looks like you entered a letter or you entered nothing. Make sure you enter a valid number.\n" +
                   $"The message of the exception is: \"{fex.Message}\"\n");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"This is an exception of {ex.GetType()} and the message of the exception is: \"{ex.Message}\"\n");
            }
            finally
            {
                Console.WriteLine("The exercise number 2 ends here. \n");
            }
        }

        public static decimal Division(decimal Number1, decimal Number2)
        {
            decimal result = Number1 / Number2;
            return result;
        }
    }
}
