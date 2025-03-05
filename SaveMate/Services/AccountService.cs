using SaveMate.Models;
using SaveMate.Repositories;

namespace SaveMate.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task AddAsync(Account account)
        {
            var userAccounts = await _accountRepository.GetAccountsByUserIdAsync(account.UserId);
            if (userAccounts.Count() >= 5)
            {
                throw new Exception("A user cannot have more than 5 accounts.");
            }

            await _accountRepository.AddAsync(account);

        }

        public async Task DeleteAsync(Guid id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found.");
            }

            await _accountRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<Account>> GetAccountsByUserIdAsync(int userId)
        {
            return _accountRepository.GetAllAsync();
        }

        public async Task<Account> GetByIdAsync(Guid id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found.");
            }
            return account;
        }

        public async Task UpdateAsync(Account account)
        {
            var existingAccount = await _accountRepository.GetByIdAsync(account.AccountId);
            if (existingAccount == null)
            {
                throw new Exception("Account not found.");
            }

            await _accountRepository.UpdateAsync(account);
        }
    }
}
