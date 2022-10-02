using System;

namespace Common.Validators
{
    public class CustomersValidator
    {

        public static string ValidateIDString(string idEnter)
        {
            GeneralValidator.ValidateTextStringLenght(idEnter, 5);

            while (true)
                if (idEnter.Length == 5)
                {
                    return idEnter;
                }
                else if (idEnter.Length < 5)
                {
                    Console.WriteLine("  You entered something with less than 5 characters, remember that the ID has 5 letters. \n" +
                            "  Try again: ");
                    idEnter = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("  You entered something with more than 5 characters, remember that the ID has 5 letters. \n" +
                              "  Try again: ");
                    idEnter = Console.ReadLine();
                }
        }
    }
}
