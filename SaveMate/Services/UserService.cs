using SaveMate.Models;
using SaveMate.Repositories;
using SaveMate.Repositories.IRepository;
using SaveMate.Services.IService;

namespace SaveMate.Services
{

    public class UserService(IUserRepository _userRepository) : IUserService
    {
        private readonly IUserRepository userRepository = _userRepository;

        public Task AddAsync(User user)
        {
           return userRepository.AddAsync(user);
        }

         public  Task DeleteAsync(User user)
        {
           return userRepository.DeleteAsync(user);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
           return userRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
          return userRepository.GetAllAsync();
        }

        public Task UpdateAsync(User user)
        {
            return userRepository.UpdateAsync(user);
        }

        public Task SaveChanges()
        {
            return userRepository.SaveAsync();
        }
    }

}
