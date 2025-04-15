using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SaveMate.Models.Enums;

namespace SaveMate.Models
{
    public class Account
    {
        public Guid AccountId { get; set; } = Guid.NewGuid(); 

        public int UserId { get; set; }

        [ValidateNever]
        public User? User { get; set; }

        public AccountType PredefinedType { get; set; }

     

        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Transaction> Transactions { get; set; } = [];
    }
}
