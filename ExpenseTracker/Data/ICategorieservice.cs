using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Data
{
    public interface ICategorieservice
    {
        IEnumerable<Category> GetAllCategory();
        void AddCategory(Category category);
        int UpdateCategory(Category category);
        Category GetCategoryData(int id);
        void DeleteCategory(int id);
        int CheckDublicateCategoryData(Category category);

    }
}
