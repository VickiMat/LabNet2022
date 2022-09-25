using Practica.EF.Entities;
using Practica.EF.Logic;
using System;
using System.Net;

namespace Practica.EF.UI
{
    public abstract class ConsoleHelper
    {
        private static int AnotherOption()
        {
            Console.WriteLine("Do you want to choose another option? \n1-Yes\n2-No ");

            string selectCont = Console.ReadLine();

            int optCont = CustomValidator.ValidateNumberContinue(selectCont);
            if (optCont == 2)
            {
                return optCont = 9;
            }
            else return optCont = 0;
        }

        public static int ShowAllCategories()
        {
            CategoriesLogic categLogic = new CategoriesLogic();

            foreach (Categories categ in categLogic.GetAll())
            {
                Console.WriteLine(categ.CategoryName + categ.Description);
            }
            Console.WriteLine("\n The category list ends here. \n");

            int optChoose = AnotherOption();
            return optChoose;
        }

    }
}
