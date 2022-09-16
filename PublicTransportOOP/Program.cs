using PublicTransportOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PublicTransportOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PublicTransport> publicTransports = new List<PublicTransport>();

            LoadTransport();

            ShowTransport();

            Console.ReadKey();

            void LoadTransport()
            {
                Console.WriteLine("---------Please insert the passengers for public transport--------- \n");
                Console.WriteLine("      First enter the passengers for the buses \n     ------------------------------------------ \n");
                for (int i = 0; i < 5; i++)
                {
                    int adding; 
                    Console.WriteLine($"        Passengers for Bus number {i+1}:");
                    adding = int.Parse(Console.ReadLine());
                    
                    while (adding > 90)
                    {
                        Console.WriteLine("The number of passengers you entered exceed the capacity of the bus. Please consider the bus only can admit 90 passengers at max");
                        Console.WriteLine($"Enter again the number of passengers for Bus number {i + 1}");
                        adding = int.Parse(Console.ReadLine());
                    }

                    publicTransports.Add(new Bus(adding)); 
                }
                Console.WriteLine("      And now enter the passengers for the cabs \n     ------------------------------------------- \n");
                for (int i = 0; i < 5; i++)
                {
                    int adding;
                    Console.WriteLine($"        Passengers for Cab number {i + 1}:");
                    adding = int.Parse(Console.ReadLine());

                    while (adding > 4)
                    {
                        Console.WriteLine("The number of passengers you entered exceed the capacity of the cab. Please consider the cab only can admit 4 passengers at max");
                        Console.WriteLine($"Enter again the number of passengers for Cab number {i + 1}");
                        adding = int.Parse(Console.ReadLine());
                    }

                    publicTransports.Add(new Cab(adding));
                }
            }

            void ShowTransport()
            {
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("*                                                                 *");
                Console.WriteLine("*      List of public transport with respective passengers        *");
                Console.WriteLine("*                                                                 *");
                Console.WriteLine("*******************************************************************\n");
                var count = 1;
                foreach (var transport in publicTransports)
                {
                    Console.WriteLine($"     -{transport.TypeOfTransport} number {count} has {transport.Passengers} passengers. \n");
                    count++;
                    if (count > 5) count = 1;
                }
                Console.WriteLine("\n *******************************************************************");
            }          
        }
    }
}
