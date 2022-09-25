using System;
using System.Runtime.CompilerServices;

namespace Practica.EF.UI
{
    public static class CustomValidator
    {
        public static int ValidateNumberMenu(string optionEntered)
        {
            int opt;
            while (true)
            {   
                if (Int32.TryParse(optionEntered, out opt))
                {
                    if (opt > 0 && opt <= 9) break;
                    else if(opt > 9)
                    {
                        Console.WriteLine("Remember that the menu only has 9 options. \nEnter a new number: ");
                        optionEntered = Console.ReadLine();
                    }
                    else if(opt <= 0)
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
                    if(optCont == 1 || optCont == 2 )
                    break;
                    else
                    {
                        Console.WriteLine("The only option you have is \n 1- Choose another action or \n 2- End the program. \nSelect again:");
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
    }
}