using ExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class ExpenseService : IExpenseService
    {
        private ApplicationDbContext db;

        public ExpenseService(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IEnumerable<Expense> GetAllExpenses(int id)
        {
            try
            {
                return db.Expense.Where(ex => ex.UserId == id).Select(m => new Expense()
                {
                    ItemId = m.ItemId,
                    CategoryId = m.CategoryId,
                    Amount = m.Amount,
                    ExpenseDate=m.ExpenseDate,
                    UserId = m.UserId,
                    CategoryName = m.Category.Name
                }).ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Expense> GetSearchResult(int id, DateTime from, DateTime to)
        {
            List<Expense> exp = new List<Expense>();
            try
            {
                var expenseList = db.Expense.Where(e => e.UserId == id && e.ExpenseDate >= from && e.ExpenseDate <= to).Select(m => new Expense()
                {
                    ItemId = m.ItemId,
                    CategoryId = m.CategoryId,
                    Amount = m.Amount,
                    ExpenseDate = m.ExpenseDate,
                    UserId = m.UserId,
                    CategoryName = m.Category.Name
                });
                return expenseList;
            }
            catch
            {
                throw;
            }
        }

        //To Add new Expense record       
        public void AddExpense(Expense expense,int id)
        {
            try
            {
                expense.UserId = id;
                db.Expense.Add(expense);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar expense  
        public int UpdateExpense(Expense expense)
        {
            try
            {
                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the data for a particular expense  
        public Expense GetExpenseData(int id)
        {
            try
            {
                Expense expense = db.Expense.Find(id);
                return expense;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular expense  
        public void DeleteExpense(int id)
        {
            try
            {
                Expense exp = db.Expense.Find(id);
                db.Expense.Remove(exp);
                db.SaveChanges();

            }
            catch
            {
                throw;
            }
        }
        public decimal GetTotalExpense(int id)
        {
            try
            {
                decimal totalExpense = db.Expense.Where(ex => ex.UserId == id).Select(ex => ex.Amount).Sum();
                return totalExpense;
            }
            catch
            {
                throw;
            }
        }
        public decimal GetTotalExpenseByDate(int id, DateTime from, DateTime to)
        {
            try
            {
                decimal totalExpense = db.Expense.Where(ex => ex.UserId == id && ex.ExpenseDate >= from && ex.ExpenseDate <= to).Select(ex => ex.Amount).Sum();
                return totalExpense;
            }
            catch
            {
                throw;
            }
        }


    }
}
