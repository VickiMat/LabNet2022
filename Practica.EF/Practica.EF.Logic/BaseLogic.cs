using Practica.EF.Data;
using System.Collections.Generic;

namespace Practica.EF.Logic
{
    public abstract class BaseLogic<T> : ILogic<T>
    {
         protected NorthwindContext _ctx;

         public BaseLogic()
         {
            _ctx = new NorthwindContext();
         }

    

        public abstract void Add(T newT);
        public abstract void Delete(int id);
        public abstract T FindById(int id);
        public abstract List<T> GetAll();
        public abstract void Update(T newT);
    }
}
