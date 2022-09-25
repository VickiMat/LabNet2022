using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Lifetime;
using Practica.EF.Entities;
using Practica.EF.Logic;
using Practica.EF.Logic.Common;

namespace Practica.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int optionMenu;
            Console.WriteLine("-------- Welcome to the practice of Entity Framework! -------- \n");
            do
            {
                Console.WriteLine("Please choose one option: \n" +
                    "1- Show all available categories. \n" +
                    "2- Show the list of the employees. \n" +
                    "3- Add new category for the catalog. \n" +
                    "4- Edit an existing category. \n" +
                    "5- Delete an existing category. \n" +
                    "6- Add new employee. \n" +
                    "7- Edit an existing employee. \n" +
                    "8- Delete an employee. \n" +
                    "9- Finish the program. ");

                string selectOpt = Console.ReadLine();
                optionMenu = CustomValidator.ValidateNumberMenu(selectOpt);

                switch (optionMenu)
                {
                    case 1:
                        optionMenu = ConsoleHelper.ShowAllCategories();
                        break;
                    case 5:
                        bool loop = true;
                        do
                        {
                            CategoriesLogic categLogic2 = new CategoriesLogic();
                            try
                            {
                                Console.WriteLine("Enter the id number of the category you want to delete: ");
                                string selectId = Console.ReadLine();
                                int idForDelete = CustomValidator.ValidateNumberID(selectId);

                                categLogic2.Delete(idForDelete);
                                Console.WriteLine($"The category with the ID {idForDelete} has been successfully deleted.\n");
                                loop = false;
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
                        break;
                }
            }
            while (optionMenu != 9);
        
        }
    }
}
