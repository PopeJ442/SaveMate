using SaveMate.Models.Enums;

namespace SaveMate.Models
{
    public class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 

        public int UserId { get; set; }
        public User User { get; set; }

        public AccountType? PredefinedType { get; set; }

        public int? CustomTypeId { get; set; }
        public required AccountCustomType CustomType { get; set; } 

        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Transaction> Transactions { get; set; } = [];
    }
}
