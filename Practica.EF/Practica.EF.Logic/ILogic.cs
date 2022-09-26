using System.Collections.Generic;

namespace Practica.EF.Logic
{
    public interface ILogic<T>
    {
        List<T> GetAll();
        void Add(T newT);
        void Update(T newT);
        void Delete(int id);
        T FindById(int id); 
    }
}
