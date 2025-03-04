using SaveMate.Models;

namespace SaveMate.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<IEnumerable<Account>> GetAccountsByUserIdAsync(int userId);
    }
}
