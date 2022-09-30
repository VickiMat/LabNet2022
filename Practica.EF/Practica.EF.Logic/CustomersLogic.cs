using Common.Exceptions;
using Practica.EF.Data;
using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    public class CustomersLogic : BaseLogic<Customers>
    {
        public IQueryable<Customers> QueryCustomer(string idEntered)
        {
            //if (customersQuery == null)
            //{
            //    throw new NotFoundIDException(idEntered);
            //}
            var customers = _ctx.Customers;

            var query1 = from cust in customers
                                  where cust.CustomerID == idEntered
                                  select cust;

            
            return query1;
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
