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
                    "   1- Show all available categories. \n\n" +
                    "   2- Add new category for the catalog. \n\n" +
                    "   3- Edit an existing category. \n\n" +
                    "   4- Delete category. \n\n" +
                    "   5- List of suppliers by city entered. \n\n" +
                    "   6- Add new supplier. \n\n" +
                    "   7- Edit an existing supplier. \n\n" +
                    "   8- Delete supplier. \n\n" +
                    "   9- Finish the program. ");

                string selectOpt = Console.ReadLine();
                int optionMenu = GeneralValidator.ValidateNumberMenu(selectOpt, 9);
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
                categName = GeneralValidator.ValidateStringLenght(categName,15);
                Console.WriteLine("Great. And now insert the description for the category:");
                string categDescrip = Console.ReadLine();
                categDescrip = GeneralValidator.ValidateStringLenght(categDescrip, 300);

                categLogic.Add(new Categories { CategoryName = categName, Description = categDescrip });

                Console.WriteLine("The category was inserted succesfully! \n Press a key to continue...");
                Console.ReadKey();
            }

            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred " + ex.Message);
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
                    categName = GeneralValidator.ValidateStringLenght(categName,15);
                    Console.WriteLine("Perfect. And now insert the description for the category:");
                    string categDescrip = Console.ReadLine();
                    categDescrip = GeneralValidator.ValidateStringLenght(categDescrip,300);

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
                    Console.WriteLine("An unexpected error occurred " + ex.Message);
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
                    Console.WriteLine("An unexpected error occurred " + ex.Message);
                }
            }
            while (loop);
        }

        public static void ShowSuppliersByCity()
        {
            bool loop2 = true;
            do
            {
                try
                {
                    ISuppliersLogic<Suppliers> supLogic = new SuppliersLogic();

                    Console.WriteLine("  Please enter the name of the city:");
                    var cityNameEntered = Console.ReadLine();
                    cityNameEntered = GeneralValidator.ValidateStringLenght(cityNameEntered, 15);

                    if (supLogic.FindSuppliersByCity(cityNameEntered).Count == 0)
                    {
                        Console.WriteLine("  There is no supplier in that city. \n" +
                            "  Try with another city like 'Paris'.");
                    }
                    else
                    {
                        Console.WriteLine($"------ List of suppliers in {cityNameEntered.ToUpper()} ------\n");
                   
                        foreach (var sup in supLogic.FindSuppliersByCity(cityNameEntered))
                        {
                            Console.WriteLine($" * Company name: {sup.CompanyName}. - Contact name: {sup.ContactName}. \n");
                        }
                        Console.WriteLine("------ The list ends here ------ \n\n Press a key to continue...");
                        loop2 = false;
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred. " + ex.Message);
                }
            }
            while(loop2); 
        }

        public static void AddSupplier()
        {
            try
            {
                ILogic<Suppliers> supLogic = new SuppliersLogic();

                Console.WriteLine("To insert a new supplier, first enter the company name:");
                string companyName = Console.ReadLine();
                companyName = GeneralValidator.ValidateStringLenght(companyName, 40);

                Console.WriteLine("Great. Now insert the contact name for the supplier:");
                string contactName = Console.ReadLine();
                contactName = GeneralValidator.ValidateStringLenght(contactName, 30);

                Console.WriteLine("Finally insert the city name for the supplier:");
                string cityName = Console.ReadLine();
                cityName = GeneralValidator.ValidateStringLenght(cityName, 15);

                supLogic.Add(new Suppliers { CompanyName = companyName, ContactName = contactName, City = cityName });

                Console.WriteLine("The supplier was inserted succesfully! \n Press a key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred" + ex.Message);
            }
        }

        public static void UpdateSupplier()
        {
            bool loop = true;
            do
            {
                try
                {
                    ILogic<Suppliers> supLogic = new SuppliersLogic();

                    Console.WriteLine("  Enter the id number of the supplier you want to update: ");
                    string selectId = Console.ReadLine();
                    int idForUpdate = GeneralValidator.ValidateNumberID(selectId);

                    supLogic.FindById(idForUpdate);

                    Console.WriteLine("  Great, the id number exists. Now enter the new company name for the supplier:");
                    string companyName = Console.ReadLine();
                    companyName = GeneralValidator.ValidateStringLenght(companyName, 40);

                    Console.WriteLine("  Perfect. Now insert the contact name for the supplier:");
                    string contactName = Console.ReadLine();
                    contactName = GeneralValidator.ValidateStringLenght(contactName, 30);

                    Console.WriteLine("  Finally enter the name of the city:");
                    string cityName = Console.ReadLine();
                    cityName = GeneralValidator.ValidateStringLenght(cityName, 15);

                    supLogic.Update(new Suppliers { SupplierID = idForUpdate, CompanyName = companyName, ContactName = contactName, City = cityName });
                    loop = false;
                    Console.WriteLine($"  The supplier with ID - {idForUpdate} was updated succesfully! \n Press a key to continue...");
                    Console.ReadKey();

                }
                catch (NotFoundIDException nex)
                {
                    Console.WriteLine(nex.Message);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred " + ex.Message);
                }
            }
            while (loop);
        }

        public static void DeleteSupplier()
        {
            bool loop = true;
            do
            {
                ILogic<Suppliers> supLogic = new SuppliersLogic();
                try
                {
                    Console.WriteLine("  Enter the id number of the supplier you want to delete: ");
                    string selectId = Console.ReadLine();
                    int idForDelete = GeneralValidator.ValidateNumberID(selectId);

                    supLogic.Delete(idForDelete);
                    Console.WriteLine($"  The supplier with the ID {idForDelete} has been successfully deleted.\n  Press a key to continue...");
                    loop = false;
                    Console.ReadKey();
                }
                catch (NotFoundIDException nex)
                {
                    Console.WriteLine(nex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("  An unexpected error occurred " + ex.Message);
                }
            }
            while (loop);
        }
    }
}
