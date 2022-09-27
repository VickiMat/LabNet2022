using Common;
using Common.Exceptions;
using Common.Validators;
using Practica.EF.Entities;
using Practica.EF.Logic;
using System;


namespace Practica.EF.UI
{
    public abstract class ConsoleHelper
    {
        public static int StartMenu()
        {
            try
            {
                Console.WriteLine(" Please choose one option: \n\n" +
                    "   1- Show all available categories. \n" +
                    "   2- Add new category for the catalog. \n" +
                    "   3- Edit an existing category. \n" +
                    "   4- Delete an existing category. \n" +
                    "   5- Show the list of the employees. \n" +
                    "   6- Add new employee. \n" +
                    "   7- Edit an existing employee. \n" +
                    "   8- Delete an employee. \n" +
                    "   9- Finish the program. ");

                string selectOpt = Console.ReadLine();
                int optionMenu = GeneralValidator.ValidateNumberMenu(selectOpt);
                return optionMenu;
            }
            catch(Exception ex)
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
                    Console.WriteLine("Don't you want to stay a little longer? \n1-Yes\n2-No ");
                }
                else
                {
                    Console.WriteLine("Do you want to choose another option? \n1-Yes\n2-No ");
                }

                string selectCont = Console.ReadLine();
                int optCont = GeneralValidator.ValidateNumberContinue(selectCont);
                if (optCont == 2)
                {
                    return optCont = 9;
                }
                else return optCont = 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine("An unexpected error occurred. " + ex.Message);
            }
            return 0;  
        }

        public static void ShowAllCategories()
        {
            try
            {
                ILogic < Categories > categLogic = new CategoriesLogic();

                Console.WriteLine("----- List of categories -----\n");
                Console.WriteLine("    ID      |         Name and description \n");
                foreach (Categories categ in categLogic.GetAll())
                {
                    Console.WriteLine($"  * {categ.CategoryID}         {categ.CategoryName} -> {categ.Description}.\n");
                }
                Console.WriteLine("\n ----- The category list ends here. ----- \n Press a key to continue...");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddCategory()
        {
            try
            {
                ILogic <Categories> categLogic = new CategoriesLogic();

                Console.WriteLine("To insert a new category, first enter the category name:");
                string categName = Console.ReadLine();
                categName = CategoryValidator.ValidateCategoryName(categName);
                Console.WriteLine("Great. And now insert the description for the category:");
                string categDescrip = Console.ReadLine();
                categDescrip = CategoryValidator.ValidateCategoryDescription(categDescrip);

                categLogic.Add(new Categories { CategoryName = categName, Description = categDescrip });

                Console.WriteLine("The category was inserted succesfully! \n Press a key to continue...");
                Console.ReadKey();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateCategory()
           {
            bool loop1 = true;
            do
            {
                try
                {
                    ILogic<Categories> categLogic = new CategoriesLogic();
     
                    Console.WriteLine("Enter the id number of the category you want to update: ");
                    string selectId = Console.ReadLine();
                    int idForUpdate = GeneralValidator.ValidateNumberID(selectId);

                    categLogic.FindById(idForUpdate);

                    Console.WriteLine("Great, the id number exists. Now enter the new name for the category:");
                    string categName = Console.ReadLine();
                    categName = CategoryValidator.ValidateCategoryName(categName);
                    Console.WriteLine("Perfect. And now insert the description for the category:");
                    string categDescrip = Console.ReadLine();
                    categDescrip = CategoryValidator.ValidateCategoryDescription(categDescrip);

                    categLogic.Update(new Categories { CategoryID = idForUpdate, CategoryName = categName , Description = categDescrip });
                    loop1 = false;
                    Console.WriteLine("The category was updated succesfully! \n Press a key to continue...");
                    Console.ReadKey();
                    
                }
                catch (NotFoundIDException nex)
                {
                    Console.WriteLine(nex.Message);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (loop1);
        }
 
        public static void DeleteCategory()
        {
            bool loop = true;
            do
            {
                ILogic<Categories> categLogic = new CategoriesLogic();
                try
                {
                    Console.WriteLine("Enter the id number of the category you want to delete: ");
                    string selectId = Console.ReadLine();
                    int idForDelete = GeneralValidator.ValidateNumberID(selectId);

                    categLogic.Delete(idForDelete);
                    Console.WriteLine($"The category with the ID {idForDelete} has been successfully deleted.\n Press a key to continue...");
                    loop = false;
                    Console.ReadKey();
                }
                catch (NotFoundIDException nex)
                {
                    Console.WriteLine(nex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (loop);
        }

        

    }
}
