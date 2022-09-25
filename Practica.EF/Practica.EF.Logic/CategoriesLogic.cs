using Practica.EF.Entities;
using Practica.EF.Logic.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica.EF.Logic
{
    public class CategoriesLogic : BaseLogic, ILogic<Categories>
    {
        public List<Categories> GetAll()
        {
            return ctx.Categories.ToList();
        }

        public void Add(Categories newCat)
        {
            ctx.Categories.Add(newCat);

            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var categForDelete = ctx.Categories.Find(id);

            if (categForDelete == null) { throw new NotFoundIDException(id); }
            else
            {
                ctx.Categories.Remove(categForDelete);

                ctx.SaveChanges();
            }
        }

        public void Update(Categories newCat)
        {
            throw new NotImplementedException();
        }
    }






}
