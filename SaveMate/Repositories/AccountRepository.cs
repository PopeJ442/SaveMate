using Microsoft.EntityFrameworkCore;
using SaveMate.ApplicationDbContext;
using SaveMate.Models;
using SaveMate.Repositories.IRepository;
using System;

namespace SaveMate.Repositories
{
    public class AccountRepository(SaveMateDbContext context) : BaseRepository<Account>(context), IAccountRepository
    { 
        public async Task<IEnumerable<Account>> GetAccountsByUserIdAsync(int userId)
        {
            return await _context.Accounts.Where(a => a.UserId == userId).ToListAsync();
        }
    }
}