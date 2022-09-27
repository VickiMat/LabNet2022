using Common.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Validators
{
    public static class GeneralValidator
    {
        public static int ValidateNumberMenu(string optionEntered)
        {
            int opt;
            while (true)
            {
                if (Int32.TryParse(optionEntered, out opt))
                {
                    if (opt > 0 && opt <= 9) break;
                    else if (opt > 9)
                    {
                        Console.WriteLine("Remember that the menu only has 9 options. \nEnter a new number: ");
                        optionEntered = Console.ReadLine();
                    }
                    else if (opt <= 0)
                    {
                        Console.WriteLine("Remember that negative numbers and zero are not allowed. \nEnter a new number: ");
                        optionEntered = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Are you trying to break the console? Please insert a valid number: ");
                    optionEntered = Console.ReadLine();
                }
            }
            return opt;
        }

        public static int ValidateNumberID(string idEntered)
        {
            int id;
            while (true)
            {
                if (Int32.TryParse(idEntered, out id))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Are you trying to break the console? Please insert an ID number: ");
                    idEntered = Console.ReadLine();
                }
            }
            return id;
        }

        public static int ValidateNumberContinue(string contSelect)
        {
            int optCont;
            while (true)
            {
                if (Int32.TryParse(contSelect, out optCont))
                {
                    if (optCont == 1 || optCont == 2)
                        break;
                    else
                    {
                        Console.WriteLine("The only 2 options you have are: \n 1- Choose another action. \n 2- End the program. \nSelect again:");
                        contSelect = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Are you trying to break the console? Please insert a number: ");
                    contSelect = Console.ReadLine();
                }
            }
            return optCont;
        }

        public static string ValidateStringLenght(string stringToValidate, int lenghtOfString)
        {
            while (true)
                if (CharValidateExtension.ValidateBasicString(stringToValidate))
                {
                    if (stringToValidate.Length <= lenghtOfString) { return stringToValidate; }
                    else
                    {
                        Console.WriteLine($" You entered a name that is too long! It must be less than {lenghtOfString} chars");
                        stringToValidate = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine(" You entered something not valid. Remember that special characters are not allowed. \n Please try again.");
                    stringToValidate = Console.ReadLine();
                }
        }
    }
}
