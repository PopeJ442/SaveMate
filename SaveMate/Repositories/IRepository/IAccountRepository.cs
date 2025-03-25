using SaveMate.Models;

namespace SaveMate.Repositories.IRepository
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<IEnumerable<Account>> GetAccountsByUserIdAsync(int userId);
    }
}
