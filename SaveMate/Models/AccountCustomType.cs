using System.ComponentModel.DataAnnotations;

namespace SaveMate.Models
{
    public class AccountCustomType
    {
       public int Id { get; set; }
        public int CustomTypeId { get; set; }

        public int UserId { get; set; } 
        public User User { get; set; }

        [Required]
        public string TypeName { get; set; } = string.Empty;
    }
}
