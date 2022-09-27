using System.Collections.Generic;

namespace Practica.EF.Logic
{
    public interface ISuppliersLogic<T>
    {
        List<T> FindSuppliersByCity(string cityName);

    }
}
