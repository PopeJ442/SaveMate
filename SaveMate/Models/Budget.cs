using SaveMate.Models.Enums;

namespace SaveMate.Models
{
    public class Budget
    {
       public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public CategoryType? PredefinedCategory { get; set; } 

        public int? CategoryId { get; set; } 
        public Category Category { get; set; }

        public decimal LimitAmount { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
