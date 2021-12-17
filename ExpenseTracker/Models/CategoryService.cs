using ExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class CategoryService : ICategorieservice
    {
        private ApplicationDbContext db;

        public CategoryService(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IEnumerable<Category> GetAllCategory()
        {
            try
            {
                return db.Category.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new Category record       
        public void AddCategory(Category category)
        {
            try
            {
                db.Category.Add(category);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar Category  
        public int UpdateCategory(Category category)
        {
            try
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the data for a particular Category  
        public Category GetCategoryData(int id)
        {
            try
            {
                Category category = db.Category.Find(id);
                return category;
            }
            catch
            {
                throw;
            }
        }

        public int CheckDublicateCategoryData(Category category)
        {
            try
            {
                var categoryData = db.Category.Where(x => x.CategoryId != category.CategoryId && x.Name == category.Name).Select(x => x.Name).FirstOrDefault();

                if (category.Name == categoryData) return 1;
                else return 0;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular Category  
        public void DeleteCategory(int id)
        {
            try
            {
                Category cat = db.Category.Find(id);
                db.Category.Remove(cat);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }


    }
}
