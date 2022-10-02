using System;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            Console.WriteLine("----- Welcome to the practice of LINQ -----\n");

            do
            {
                option = ConsoleHelperMenu.StartMenu();

                switch (option)
                {
                    case 1:
                        ConsoleHelperLINQ.Exercise1();
                        break;

                    case 2:
                        ConsoleHelperLINQ.Exercise2();
                        break;

                    case 3:
                        ConsoleHelperLINQ.Exercise3();
                        break;

                    case 4:
                        ConsoleHelperLINQ.Exercise4();
                        break;

                    case 5:
                        ConsoleHelperLINQ.Exercise5();
                        break;

                    case 6:
                        ConsoleHelperLINQ.Exercise6();
                        break;

                    case 7:
                        ConsoleHelperLINQ.Exercise7();
                        break;

                    case 8:
                        ConsoleHelperLINQ.Exercise8();
                        break;

                    case 9:
                        ConsoleHelperLINQ.Exercise9();
                        break;

                    case 10:
                        ConsoleHelperLINQ.Exercise10();
                        break;

                    case 11:
                        ConsoleHelperLINQ.Exercise11();
                        break;

                    case 12:
                        ConsoleHelperLINQ.Exercise12();
                        break;

                    case 13:
                        ConsoleHelperLINQ.Exercise13();
                        break;
                }
                option = ConsoleHelperMenu.AnotherOption(option == 14);
            }
            while (option!= 14);
        } 
    }
}
