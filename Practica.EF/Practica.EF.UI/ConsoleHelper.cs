using Practica.EF.Entities;
using Practica.EF.Logic;
using System;


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
            int optChoose = 0;
            try
            {
                CategoriesLogic categLogic = new CategoriesLogic();

                foreach (Categories categ in categLogic.GetAll())
                {
                    Console.WriteLine(categ.CategoryName + categ.Description);
                }
                Console.WriteLine("\n The category list ends here. \n");

                optChoose = AnotherOption();
                return optChoose;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return optChoose;
        }

        public static int AddCategory()
        {
            int optChoose = 0;
            try
            {
                CategoriesLogic categLogic = new CategoriesLogic();

                Console.WriteLine("To insert a new category, first enter the category name:");
                string categName = Console.ReadLine();
                categName = CustomValidator.ValidateCategoryName(categName);
                Console.WriteLine("Great. And now insert the description for the category:");
                string categDescrip = Console.ReadLine();
                categDescrip = CustomValidator.ValidateCategoryDescription(categDescrip);

                categLogic.Add(new Categories { CategoryName = categName, Description = categDescrip });

                Console.WriteLine("The category was inserted succesfully!");

                optChoose = AnotherOption();
                return optChoose;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return optChoose;
        }

    }
}
