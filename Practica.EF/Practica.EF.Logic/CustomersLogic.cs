using Common.Exceptions;
using Practica.EF.Entities;
using Practica.EF.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Practica.EF.Logic
{
    public class CustomersLogic : BaseLogic<Customers>
    {
        //Query 1 - Exercise 1
        public Customers QueryCustomer(string idEntered)
        {
            var customers = _ctx.Customers;

            return customers.Where(c => c.CustomerID == idEntered)
                            .FirstOrDefault();
        }

        //Query 4 - Exercise 4
        public IQueryable<Customers> CustomersRegionWA()
        {
            var customers = _ctx.Customers;

            return customers.Where(c => c.Region == "WA");
        }

        //Query 8 - Exercise 8
        public IQueryable<Customers> ThreeCustomersRegionWA()
        {
            var customers = _ctx.Customers;

            return customers.Where(c => c.Region == "WA")
                            .Take(3);                          
        }

        //Query 6 - Exercise 6
        public IQueryable<string> CustomersName()
        {
            var customers = _ctx.Customers;

            return customers.Select(c => c.CompanyName);
        }

        //Query 7 - Exercise 7
        public IQueryable<CustomersOrdersDto> CustomersFromRegion_AndOrdersFromDate()
        {
            var customers = _ctx.Customers;
            var orders = _ctx.Orders;

            DateTime specificDate = new DateTime(1997, 01, 01);

            return from c in customers
                   join o in orders
                   on c.CustomerID equals o.CustomerID
                   where c.Region == "WA" && o.OrderDate > specificDate
                   select new CustomersOrdersDto
                   {
                       CustomerID = c.CustomerID,
                       Region = c.Region,
                       OrderDate = o.OrderDate,
                       CompanyName = c.CompanyName,
                       OrderID = o.OrderID
                   };
        }

        //Query 13 - Exercise 13
        public IQueryable<CustomersOrdersDto> CustomersWithNumberOfOrders()
        {
            var customers = _ctx.Customers;
            var orders = _ctx.Orders;

            return from c in customers
                   join o in orders
                   on c.CustomerID equals o.CustomerID
                   group c by new
                   {
                       CompanyName = c.CompanyName,
                       CustomerID = c.CustomerID
                   }
                   into co
                   select new CustomersOrdersDto
                   {
                       NumberOfOrders = co.Count(),
                       CustomerID = co.Key.CustomerID,
                       CompanyName = co.Key.CompanyName
                   };
        }


        public Customers FindById(string idEnter)
        {
            try
            {
                var customerById = _ctx.Customers.Find(idEnter);
                if (customerById == null) { throw new NotFoundIDException(idEnter); }
                else
                {
                    return customerById;
                }
            }
            catch (NotFoundIDException)
            {
                throw new NotFoundIDException(idEnter);
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public override void Add(Customers newT)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Customers FindById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Customers> GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Update(Customers newT)
        {
            throw new NotImplementedException();
        }
    }
}
