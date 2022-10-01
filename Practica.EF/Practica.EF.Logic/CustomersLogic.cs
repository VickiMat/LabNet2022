using Common.Exceptions;
using Practica.EF.Data;
using Practica.EF.Entities;
using Practica.EF.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    public class CustomersLogic : BaseLogic<Customers>
    {
        public Customers QueryCustomer(string idEntered)
        {
            var customers = _ctx.Customers;

            var query1 = customers.Take(1);

            return query1.First();
        }

        public IQueryable<Customers> CustomersRegionWA()
        {
            var customers = _ctx.Customers;
            
            var query4 = customers.Where(c => c.Region == "WA");

            return query4;
        }

        public IQueryable<Customers> ThreeCustomersRegionWA()
        {
            var customers = _ctx.Customers;

            var query8 = customers.Where(c => c.Region == "WA")
                                  .Take(3);                          
            return query8;
        }

        public IQueryable<string> CustomersName()
        {
            var customers = _ctx.Customers;

            var query6 = customers.Select(c => c.ContactName);

            return query6;
        }

        public IQueryable<CustomersOrdersDto> CustomersFromRegion_AndOrdersFromDate()
        {
            var customers = _ctx.Customers;
            var orders = _ctx.Orders;

            DateTime specificDate = new DateTime(1997, 01, 01);

            var query7 = from c in customers
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

            return query7;
        }

        public IQueryable<CustomersOrdersDto> CustomersWithNumberOfOrders()
        {
            var customers = _ctx.Customers;
            var orders = _ctx.Orders;

            var query13 = from c in customers
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

            return query13;
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
