using Practica.EF.Entities;
using System.Collections.Generic;

namespace Practica.EF.Service
{
    public interface ICategoriesService
    {
        List<Categories> GetCategories();

        Categories GetCategoryById(int id);

        void AddCategory(Categories category);

        void UpdateCategory(Categories category);

        void DeleteCategory(int id);
    }
}
