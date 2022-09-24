using System;
using Practica.EF.Entities;
using Practica.EF.Logic;


namespace Practica.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CategoriesLogic categLogic = new CategoriesLogic();

            foreach (Categories categ in categLogic.GetAll())
            {
                Console.WriteLine(categ.CategoryName + categ.Description);
            }

            Console.ReadKey();
        }
    }
}
