using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Http;

namespace ExpenseTracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseService expenseService;

        private readonly ApplicationDbContext db;
        public ExpensesController(IExpenseService _expenseService, ApplicationDbContext _db)
        {
            expenseService = _expenseService;
            db=_db;
        }
        public IActionResult Index(string from, string to)
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.Session.GetString("id"));
                List<Expense> lstExpense = new List<Expense>();
                lstExpense = expenseService.GetAllExpenses(id).ToList();
                if (lstExpense.Count > 0) ViewBag.TotalExpense = expenseService.GetTotalExpense(id);
                if (!string.IsNullOrEmpty(from))
                {
                    DateTime start = Convert.ToDateTime(from + " 00:00:00");
                    string todateTime = DateTime.Now.ToString("dd/MM/yyyy") + " 23:59:59";
                    DateTime end = DateTime.ParseExact(todateTime, "dd/MM/yyyy HH:mm:ss", null);
                    if (!string.IsNullOrEmpty(to))
                    {
                        end = Convert.ToDateTime(to + " 23:59:59");
                    }
                    lstExpense = expenseService.GetSearchResult(id, start, end).ToList();
                    if (lstExpense.Count > 0) ViewBag.TotalExpense = expenseService.GetTotalExpenseByDate(id, start, end);
                }
                return View(lstExpense);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public ActionResult AddEditExpenses(int itemId)
        {
            try
            {
                Expense model = new Expense();
                if (itemId > 0)
                {
                    model = expenseService.GetExpenseData(itemId);
                    ViewData["CategoryId"] = new SelectList(db.Category, "CategoryId", "Name", model.CategoryId);
                }
                else ViewData["CategoryId"] = new SelectList(db.Category, "CategoryId", "Name");

                return PartialView("_expenseForm", model);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpPost]
        public ActionResult Create(Expense expense)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int todayDate = Convert.ToInt32(DateTime.Now.ToString("MMddyyyy"));
                    int fromDate = Convert.ToInt32(expense.ExpenseDate.ToString("MMddyyyy"));
                    if (fromDate > todayDate) return View();

                    if (expense.ItemId > 0)
                    {
                        ViewData["CategoryId"] = new SelectList(db.Category, "CategoryId", "Name", expense.CategoryId);
                        expenseService.UpdateExpense(expense);
                    }
                    else
                    {
                        ViewData["CategoryId"] = new SelectList(db.Category, "CategoryId", "Name");
                        int id = Convert.ToInt32(HttpContext.Session.GetString("id"));
                        expenseService.AddExpense(expense, id);
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
                expenseService.DeleteExpense(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        
    }
}
