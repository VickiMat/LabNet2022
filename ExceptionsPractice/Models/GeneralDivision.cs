using System;

namespace ExceptionsPractice.Models
{
    public class GeneralDivision : DivideNumbers
    {
        public static void Division()
        { 
            try
            {
                Console.WriteLine("Please insert two numbers to do the division");
                Console.WriteLine("Number 1:");
                decimal Number1 = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Number 2:");
                decimal Number2 = decimal.Parse(Console.ReadLine());
                decimal result = Division(Number1,Number2);
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
            catch(OverflowException)
            {
                Console.WriteLine($"The value you are trying to enter is too big or too low \n");
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

        
    }
}
