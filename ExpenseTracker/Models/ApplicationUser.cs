using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class ApplicationUser
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<Expense> Expense { get; set; }
    }
}
