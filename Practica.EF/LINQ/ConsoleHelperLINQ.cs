using Practica.EF.Logic;
using System;

namespace LINQ
{
    public abstract class ConsoleHelperLINQ
    {
        //public static void Exercise1()
        //{
        //    try
        //    {
        //        CustomersLogic custLogic = new CustomersLogic();

        //        Console.WriteLine("  Please insert the id of the customer you wanna search, remember that the id is made up of 5 letters: ");
        //        string idEnter = Console.ReadLine();
        //        CustomersValidator.ValidateIDString(idEnter).ToUpper();

        //        var customer = custLogic.QueryCustomer(idEnter);

        //        foreach (var item in customer)
        //        {
        //            Console.WriteLine($"  Customer with ID {item.CustomerID} \n  Company Name: {item.CompanyName} - Contact Name: {item.ContactName} - Contact Title: {item.ContactTitle}\n" +
        //                $"  Adress: {item.Address} - City: {item.City} - Region: {item.Region} - Postal Code: {item.PostalCode} - Country: {item.Country}\n" +
        //                $"  Phone: {item.Phone} - Fax: {item.Fax}");
        //        }
                
        //    }
        //    catch(NotFoundIDException nex)
        //    {
        //        Console.WriteLine(nex.Message);
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    } 
        //}

        public static void Exercise2()
        {
            try
            {
                ProductsLogic prodLogic = new ProductsLogic();
                
                var products = prodLogic.ProductsWithoutStock();

                int iterator = 1;

                Console.WriteLine("------ List of products without stock -----\n\n");
                foreach(var product in products)
                {
                    Console.WriteLine($"  *{iterator} | ID: {product.ProductID} - Product Name: {product.ProductName} " +
                        $"- Unit Price: {product.UnitPrice} - Units in stock {product.UnitsInStock}\n");

                    iterator++;
                }
                Console.WriteLine("----- End of the list -----\n");
                Console.WriteLine("  Press a key to continue...");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Exercise3()

        {
            try
            {
                ProductsLogic prodLogic = new ProductsLogic();

                var products = prodLogic.ProductsWithStockAndPriceOver3();

                int iterator = 1;

                Console.WriteLine("------ List of products with stock and price over 3 per unit -----\n\n");
                foreach (var product in products)
                {
                    Console.WriteLine($"  *{iterator} | ID: {product.ProductID} - Product Name: {product.ProductName} " +
                        $"- Unit Price: {product.UnitPrice} - Units in stock {product.UnitsInStock}\n");

                    iterator++;
                }
                Console.WriteLine("----- End of the list -----\n");
                Console.WriteLine("  Press a key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Exercise4()
        {
            try
            {
                CustomersLogic custLogic = new CustomersLogic();

                var customers = custLogic.CustomersRegionWA();
                int iterator = 1;
                Console.WriteLine("---- List of customers with region equal to WA -----\n\n");
                foreach (var cust in customers)
                {
                    Console.WriteLine($"  *{iterator} | ID: {cust.CustomerID} - Company Name: {cust.CompanyName} - Contact Name: {cust.ContactName} - Contact Title: {cust.ContactTitle}\n" +
                        $"  Adress: {cust.Address} - City: {cust.City} - Region: {cust.Region} - Postal Code: {cust.PostalCode} - Country: {cust.Country}\n" +
                        $"  Phone: {cust.Phone} - Fax: {cust.Fax} \n");
                    iterator++;
                }
                Console.WriteLine("----- The list ends here -----\n");
                Console.WriteLine("  Press a key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //public static void Exercise5()
        //{
        //    try
        //    {
        //        ProductsLogic prodLogic = new ProductsLogic();

        //        var product = prodLogic.ProductWithID_789_OrNull();

        //        if (product == null || product.ToString().Length == 0)
        //        {
        //            Console.WriteLine("  There is no product available with that id.");
        //            Console.WriteLine("  Press a key to continue...\n");
        //            Console.ReadKey();
        //        }
        //        else Console.WriteLine($"  The product with ID 789 is {product.ProductName}.\n");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        public static void Exercise6()
        {
            try
            {
                CustomersLogic custLogic = new CustomersLogic();

                var customersNames = custLogic.CustomersName();

                Console.WriteLine("----- List of customers names in uppercase and lowercase -----\n");
                foreach (var custName in customersNames)
                {
                    Console.WriteLine($"  * UPPER NAME : {custName.ToUpper()} | lower name : {custName.ToLower()} \n");
                }

                Console.WriteLine("----- The list ends here -----\n");
                Console.WriteLine("  Press a key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Exercise7()
        {
            try
            {
                CustomersLogic custLogic = new CustomersLogic();
                int iterator = 1;
                var customersAndOrders = custLogic.CustomersFromRegion_AndOrdersFromDate();

                Console.WriteLine("  List of customers and orders where the region is WA and the date of the order is after 1997/01/01\n\n");
                foreach(var item in customersAndOrders)
                {
                    Console.WriteLine($"  *{iterator} | Customer ID: {item.CustomerID} - Company Name: {item.CompanyName} - Region: {item.Region}\n" +
                        $"  Order ID: {item.OrderID} - Order date: {item.OrderDate}\n");
                    iterator++;
                }
                Console.WriteLine("----- The list ends here -----\n");
                Console.WriteLine("  Press a key to continue...");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Exercise8()
        {
            try
            {
                CustomersLogic custLogic = new CustomersLogic();

                var customers = custLogic.ThreeCustomersRegionWA();

                Console.WriteLine("  The first 3 customers with the region in WA are: \n\n");
                
                foreach(var cust in customers)
                {
                    Console.WriteLine($"  * ID: {cust.CustomerID} - Company Name: {cust.CompanyName} - Contact Name: {cust.ContactName} - Contact Title: {cust.ContactTitle}\n" +
                      $"  Adress: {cust.Address} - City: {cust.City} - Region: {cust.Region} - Postal Code: {cust.PostalCode} - Country: {cust.Country}\n" +
                      $"  Phone: {cust.Phone} - Fax: {cust.Fax} \n");
                }
                Console.WriteLine("\n  Press a key to continue...");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static void Exercise9()
        {
            try
            {
                ProductsLogic prodLogic = new ProductsLogic();

                var products = prodLogic.ProductsOrderBy_Name();

                int iterator = 1;

                Console.WriteLine("----- List of products order by name -----\n\n");
                foreach(var product in products)
                {
                    Console.WriteLine($"  *{iterator} | ID: {product.ProductID} - Product Name: {product.ProductName} " +
                           $"- Unit Price: {product.UnitPrice} - Units in stock {product.UnitsInStock}\n");

                    iterator++;
                }
                Console.WriteLine("----- End of the list -----\n");
                Console.WriteLine("  Press a key to continue...");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Exercise10()
        {
            try
            {
                ProductsLogic prodLogic = new ProductsLogic();

                var products = prodLogic.ProductsOrderBy_UnitsInStock();

                int iterator = 1;

                Console.WriteLine("----- List of products order by units in stock descending -----\n\n");
                foreach (var product in products)
                {
                    Console.WriteLine($"  *{iterator} | ID: {product.ProductID} - Product Name: {product.ProductName} " +
                           $"- Unit Price: {product.UnitPrice} - Units in stock {product.UnitsInStock}\n");

                    iterator++;
                }
                Console.WriteLine("----- End of the list -----\n");
                Console.WriteLine("  Press a key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //public static void Exercise11()
        //{
        //    try
        //    {
        //        CategoriesLogic categLogic = new CategoriesLogic();

        //        int iterator = 1;

        //        var categories = categLogic.CategoriesAssociateProducts();

        //        Console.WriteLine("----- List of categories with products -----\n");
        //        foreach (var category in categories)
        //        {
        //            Console.WriteLine($"  *{iterator} | ID: {category.CategoryID} - Category Name: {category.CategoryName}");
        //            iterator++;
        //        }
        //        Console.WriteLine("----- The list ends here ------\n");
        //        Console.WriteLine("  Press a key to continue...");
        //        Console.ReadKey();
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //}

        public static void Exercise12()
        {
            try
            {
                ProductsLogic prodLogic = new ProductsLogic();

                Console.WriteLine(" The first element in a list of products is: \n");
                var element = prodLogic.GetFirstProduct();

                Console.WriteLine($"   * ID: {element.ProductID} - Product Name: {element.ProductName}");
                Console.WriteLine("\n\n Press a key to continue...");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

     
        public static void Exercise13()
        {
            try
            {
                CustomersLogic custLogic = new CustomersLogic();
                int iterator = 1;
                var customersAndOrders = custLogic.CustomersWithNumberOfOrders();

                Console.WriteLine("  List of customers and numbers of orders associate\n\n");
                foreach (var item in customersAndOrders)
                {
                    Console.WriteLine($"  *{iterator} | Customer ID: {item.CustomerID} - Company Name: {item.CompanyName}\n" +
                        $"  Number of orders {item.NumberOfOrders}\n");
                    iterator++;
                }
                Console.WriteLine("----- The list ends here -----\n");
                Console.WriteLine("  Press a key to continue...");
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
