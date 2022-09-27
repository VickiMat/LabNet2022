using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    public class SuppliersLogic : BaseLogic<Suppliers>, ISuppliersLogic<Suppliers>
    {
        public override void Add(Suppliers newT)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Suppliers FindById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Suppliers> GetAll()
        {
            try
            {
                return _ctx.Suppliers.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(Suppliers newT)
        {
            throw new NotImplementedException();
        }

        public List<Suppliers> FindSuppliersByCity(string cityName)
        {//comparar ciudad con ciudad de supplier y armar una nueva lista

            throw new NotImplementedException();
        }
    }
}
