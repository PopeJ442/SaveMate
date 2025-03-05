namespace SaveMate.Models
{
    public class Goal
    {
        public int GoalId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Name { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? Deadline { get; set; }
    }
}
