using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica.EF.Logic
{
    public class CategoriesLogic : BaseLogic, ILogic<Categories>
    {
        public void Add(Categories newT)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Categories> GetAll()
        {
            return ctx.Categories.ToList();
        }

        public void Update(Categories newT)
        {
            throw new NotImplementedException();
        }
    }






}
