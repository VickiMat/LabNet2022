using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica.EF.Logic
{
    internal class EmployeesLogic : BaseLogic, ILogic<Employees>
    {
        public void Add(Employees newEmp)
        {
            ctx.Employees.Add(newEmp);

            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employees FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employees> GetAll()
        {
            return ctx.Employees.ToList();

        }

        public void Update(Employees newT)
        {
            throw new NotImplementedException();
        }
    }
}
