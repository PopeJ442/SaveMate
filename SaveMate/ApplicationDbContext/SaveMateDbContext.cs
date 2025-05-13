using Microsoft.EntityFrameworkCore;
using SaveMate.Models;

namespace SaveMate.ApplicationDbContext
{
    public class SaveMateDbContext(DbContextOptions<SaveMateDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountCustomType> AccountCustomTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(a => a.PredefinedType)
                .HasConversion<string>();

            //modelBuilder.Entity<Transaction>()
            //.Property(t => t.Category)
            //.HasConversion<string>();
        }

    }
}
