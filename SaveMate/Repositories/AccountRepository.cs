using Microsoft.EntityFrameworkCore;
using SaveMate.ApplicationDbContext;
using SaveMate.Models;
using System;

namespace SaveMate.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(SaveMateDbContext context) : base(context) { }

        public async Task<IEnumerable<Account>> GetAccountsByUserIdAsync(int userId)
        {
            return await _context.Accounts.Where(a => a.UserId == userId).ToListAsync();
        }
    }
}
