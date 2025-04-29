using SaveMate.Models;

namespace SaveMate.ViewModel
{
    public class UserAccountViewModel
    {
        public required User user { get; set; }
        public IEnumerable<Account>? account { get; set; }
    }
}
