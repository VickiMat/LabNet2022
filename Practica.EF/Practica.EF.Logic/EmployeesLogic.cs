using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica.EF.Logic
{
    internal class EmployeesLogic : BaseLogic<Employees>
    {
        public override void Add(Employees newEmp)
        {
            _ctx.Employees.Add(newEmp);

            _ctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Employees FindById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Employees> GetAll()
        {
            return _ctx.Employees.ToList();

        }

        public override void Update(Employees newT)
        {
            throw new NotImplementedException();
        }
    }
}
