using SaveMate.Models;

namespace SaveMate.Services
{
    public interface IAccountService
    {
        Task<Account> GetByIdAsync(Guid id);
        Task<IEnumerable<Account>> GetAccountsByUserIdAsync(int userId);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(Guid id);
    }
}
