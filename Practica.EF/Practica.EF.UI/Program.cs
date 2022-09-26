using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Common;
using Common.Exceptions;
using Common.Validators;
using Practica.EF.Entities;
using Practica.EF.Logic;


namespace Practica.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CategoriesLogic categLogic3 = new CategoriesLogic();

            //Console.WriteLine($"{categLogic3.FindById(1).CategoryName} se encontro");
            //Console.ReadKey();

            //categLogic3.Update(new Categories { CategoryID = 8, CategoryName = "Sea food" });
            //ConsoleHelper.ShowAllCategories();



            int optionMenu;
            Console.WriteLine("-------- Welcome to the practice of Entity Framework! -------- \n");
            do
            {
                optionMenu = ConsoleHelper.StartMenu();

                switch (optionMenu)
                {
                    case 1:
                        ConsoleHelper.ShowAllCategories();
                        break;

                    case 2:
                        ConsoleHelper.AddCategory();
                        break;

                    case 3:
                        ConsoleHelper.UpdateCategory();
                        break;

                    case 4:
                        bool loop = true;
                        do
                        {
                            CategoriesLogic categLogic2 = new CategoriesLogic();
                            try
                            {
                                Console.WriteLine("Enter the id number of the category you want to delete: ");
                                string selectId = Console.ReadLine();
                                int idForDelete = GeneralValidator.ValidateNumberID(selectId);

                                categLogic2.Delete(idForDelete);
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
                        break;
                }
                optionMenu = ConsoleHelper.AnotherOption(optionMenu == 9);
            }
            while (optionMenu != 9);
        }
    }
}

