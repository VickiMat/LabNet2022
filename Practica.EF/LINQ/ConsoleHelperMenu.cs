using Common.Validators;
using System;

namespace LINQ
{
    public abstract class ConsoleHelperMenu
    {
        public static int StartMenu()
        {
            try
            {
                Console.WriteLine("  Please choose one option: \n\n" +
                    "   1- Return object customer. \n\n" +
                    "   2- All products out of stock. \n\n" +
                    "   3- All products that have stock and cost more than 3 per Unit. \n\n" +
                    "   4- Customers from region WA. \n\n" +
                    "   5- The first or null element of a list of products where the ID on product is equal to 789. \n\n" +
                    "   6- Name of customers in uppercase and lowercase. \n\n" +
                    "   7- Customers and orders, in region WA and order date after 1997/01/01. \n\n" +
                    "   8- 3 first customers from region WA. \n\n" +
                    "   9- Products order by name. \n\n" +
                    "   10- Products order descending by units in stock. \n\n" +
                    "   11- Categories associate with products. \n\n" +
                    "   12- First element from list of products. \n\n" +
                    "   13- Customers with numbers of orders associate. \n\n" +
                    "   14- Exit the program. \n\n");

                string selectOpt = Console.ReadLine();
                int option = GeneralValidator.ValidateNumberMenu(selectOpt, 14);
                return option;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred" + ex.Message);
            }
            return 0;
        }

        public static int AnotherOption(bool endProgram)
        {
            try
            {
                Console.Clear();
                if (endProgram)
                {
                    Console.WriteLine("  Don't you want to stay a little longer? \n\n   1-Yes\n\n   2-No ");
                }
                else
                {
                    Console.WriteLine("  Do you want to choose another option? \n\n   1-Yes\n\n   2-No ");
                }

                string selectCont = Console.ReadLine();
                int optCont = GeneralValidator.ValidateNumberContinue(selectCont);
                if (optCont == 2)
                {
                    return optCont = 14;
                }
                else return optCont = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred. " + ex.Message);
            }
            return 0;
        }
    }
}
