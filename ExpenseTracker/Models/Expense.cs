using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [Required]       
        public int Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        [Required]
        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }
    }
}
