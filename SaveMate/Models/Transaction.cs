using Microsoft.EntityFrameworkCore;
using SaveMate.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveMate.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        
        public Guid AccountId { get; set; }
        public CategoryType Category { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; } 
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
       
    }
}
