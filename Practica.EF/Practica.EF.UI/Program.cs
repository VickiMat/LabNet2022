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
                        ConsoleHelper.DeleteCategory();
                        break;

                    case 5:
                        ConsoleHelper.ShowSuppliersByCity();
                        break;
                    case 6:
                        ConsoleHelper.AddSupplier();
                        break;

                    case 7:
                        ConsoleHelper.UpdateSupplier();
                        break;

                    case 8:
                        ConsoleHelper.DeleteSupplier();
                        break;
                }
                optionMenu = ConsoleHelper.AnotherOption(optionMenu == 9);
            }
            while (optionMenu != 9);
        }
    }
}

