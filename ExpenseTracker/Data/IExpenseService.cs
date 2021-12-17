using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Data
{
    public interface IExpenseService
    {
        IEnumerable<Expense> GetAllExpenses(int id);
        IEnumerable<Expense> GetSearchResult(int id, DateTime from, DateTime to);
        void AddExpense(Expense expense,int id);
        int UpdateExpense(Expense expense);
        Expense GetExpenseData(int id);
        void DeleteExpense(int id);
        decimal GetTotalExpense(int id);
        decimal GetTotalExpenseByDate(int id, DateTime from, DateTime to);
    }
}