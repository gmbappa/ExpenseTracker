using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Data;
using ExpenseTracker.Models;

namespace ExpenseTracker.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategorieservice categorieService;

        public CategoriesController(ICategorieservice _categorieService)
        {
            categorieService = _categorieService;
        }
        // GET: Categories
        public IActionResult Index()
        {
            try
            {
                List<Category> lstCategory = new List<Category>();
                lstCategory = categorieService.GetAllCategory().ToList();
                return View(lstCategory);
            }
            catch (Exception)
            {

                throw;
            }  
            
        }

        public ActionResult AddEditCategory(int CategoryId)
        {
            try
            {
                Category model = new Category();
                if (CategoryId > 0)
                {
                    model = categorieService.GetCategoryData(CategoryId);
                }
                return PartialView("_categoryForm", model);
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (exists > 0)
                    {
                        return View();
                    }
                    if (category.CategoryId > 0)
                    {
                        categorieService.UpdateCategory(category);
                    }
                    else
                    {
                        categorieService.AddCategory(category);
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                categorieService.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        int exists = 0;
        public JsonResult CheckData(Category category)
        {
            try
            {
                exists = 0;
                exists = categorieService.CheckDublicateCategoryData(category);
                if (exists > 0)
                {
                    return Json(new { Status = "Error", Message = "Dublicate Data Exists" });
                }
                else return Json(new { Status = "ok", Message = "Success" });
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        //private bool CategoryExists(int id)
        //{
        //    return categorieService.GetCategoryData(id);
        //}
    }
}

