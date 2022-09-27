using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    public interface ISuppliersLogic<T>
    {
        List<T> FindSuppliersByCity(string cityName);

    }
}
