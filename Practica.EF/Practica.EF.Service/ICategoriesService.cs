using Practica.EF.Entities;
using System.Collections.Generic;

namespace Practica.EF.Service
{
    public interface ICategoriesService
    {
        List<Categories> GetCategories();
    }
}
