using Microsoft.EntityFrameworkCore;
using SaveMate.Models;

namespace SaveMate.ApplicationDbContext
{
    public class SaveMateDbContext(DbContextOptions<SaveMateDbContext> options) : DbContext(options)
    {
        public DbSet<User> users { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<AccountCustomType> accountCustomTypes { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Goal> goals { get; set; }
        public DbSet<Budget> budgets { get; set; }
        public DbSet<Transaction> transactions { get; set; }
        
    }
}
