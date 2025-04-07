using Microsoft.AspNetCore.Mvc;
using SaveMate.Models;
using SaveMate.Repositories.IRepository;

namespace SaveMate.Services.IService
{
    public interface IUserService 
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task SaveChanges();
    }
}
