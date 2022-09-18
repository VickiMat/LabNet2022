using System;

namespace ExceptionsPractice.Models
{
    public class ZeroDivisor : DivideNumbers
    {
        public static void Division()
        {
            try
            {
                Console.WriteLine("Please insert a number for the division:");
                decimal divisorNumber = decimal.Parse(Console.ReadLine());
                decimal result = Division(divisorNumber,0);
                Console.WriteLine(result);
            }
            catch (DivideByZeroException dex)
            {
                Console.WriteLine($"Oh oh you have an \"{dex.Message}\"\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"This is an exception of {ex.GetType()} and the message of the exception is: \"{ex.Message}\"\n");
            }
            finally
            {
                Console.WriteLine("The exercise number 1 ends anyway! \n");
            }
        }
    }
}
