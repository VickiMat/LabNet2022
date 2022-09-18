using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsPractice.Models
{
    public class ZeroDivisor 
    {
        public static void Division()
        {
            try
            {
                Console.WriteLine("Please insert a number for the division:");
                decimal divisorNumber = decimal.Parse(Console.ReadLine());
                decimal result = Division(divisorNumber);
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

        public static decimal Division(decimal Number1, decimal Number2 = 0)
        {
            decimal result = Number1 / Number2;
            return result;
        }
    }
}
