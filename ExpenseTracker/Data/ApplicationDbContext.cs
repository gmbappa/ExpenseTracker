using ExpenseTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Data
{
    public class ApplicationDbContext : DbContext //IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { UserId = 1, UserName = "pulak", Password = "123" },
                new ApplicationUser { UserId = 2, UserName = "aninda", Password = "123" },
                new ApplicationUser { UserId = 3, UserName = "Mostafa", Password = "123" }
            );
            modelBuilder.Entity<Category>().HasData(
               new Category { CategoryId = 1, Name = "House Rent" },
               new Category { CategoryId = 2, Name = "Water Bill" },
               new Category { CategoryId = 3, Name = "Electric Bill" },
               new Category { CategoryId = 4, Name = "Groceries" },
               new Category { CategoryId = 5, Name = "Uber" },
               new Category { CategoryId = 6, Name = "Medications" }
           );

            modelBuilder.Entity<Expense>().HasData(
              new Expense { UserId = 1, ItemId = 1, ExpenseDate = DateTime.Now, Amount = 10000, CategoryId = 1 },
              new Expense { UserId = 1, ItemId = 2, ExpenseDate = DateTime.Now, Amount = 600, CategoryId = 2 },
              new Expense { UserId = 1, ItemId = 3, ExpenseDate = DateTime.Now, Amount = 1000, CategoryId = 3 },
              new Expense { UserId = 1, ItemId = 4, ExpenseDate = DateTime.Now, Amount = 5000, CategoryId = 4 },
              new Expense { UserId = 1, ItemId = 5, ExpenseDate = DateTime.Now, Amount = 2000, CategoryId = 5 },
              new Expense { UserId = 1, ItemId = 6, ExpenseDate = DateTime.Now, Amount = 3000, CategoryId = 6 },

              new Expense { UserId = 2, ItemId = 7, ExpenseDate = DateTime.Now, Amount = 8000, CategoryId = 1 },
              new Expense { UserId = 2, ItemId = 8, ExpenseDate = DateTime.Now, Amount = 600, CategoryId = 2 },
              new Expense { UserId = 2, ItemId = 9, ExpenseDate = DateTime.Now, Amount = 1000, CategoryId = 3 },
              new Expense { UserId = 2, ItemId = 10, ExpenseDate = DateTime.Now, Amount = 5000, CategoryId = 4 },
              new Expense { UserId = 2, ItemId = 11, ExpenseDate = DateTime.Now, Amount = 2000, CategoryId = 5 },
              new Expense { UserId = 2, ItemId = 12, ExpenseDate = DateTime.Now, Amount = 3000, CategoryId = 6 },

              new Expense { UserId = 3, ItemId = 13, ExpenseDate = DateTime.Now, Amount = 3000, CategoryId = 1 },
              new Expense { UserId = 3, ItemId = 14, ExpenseDate = DateTime.Now, Amount = 600, CategoryId = 2 },
              new Expense { UserId = 3, ItemId = 15, ExpenseDate = DateTime.Now, Amount = 1000, CategoryId = 3 },
              new Expense { UserId = 3, ItemId = 16, ExpenseDate = DateTime.Now, Amount = 5000, CategoryId = 4 },
              new Expense { UserId = 3, ItemId = 17, ExpenseDate = DateTime.Now, Amount = 2000, CategoryId = 5 },
              new Expense { UserId = 3, ItemId = 18, ExpenseDate = DateTime.Now, Amount = 3000, CategoryId = 6 }
          );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
