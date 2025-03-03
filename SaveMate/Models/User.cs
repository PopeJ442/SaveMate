namespace SaveMate.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Account> Accounts { get; set; } = [];
        public ICollection<Budget> Budgets { get; set; } = [];
        public ICollection<Goal> Goals { get; set; } = [];
        public ICollection<Category> Categories { get; set; } = [];

    }
}
