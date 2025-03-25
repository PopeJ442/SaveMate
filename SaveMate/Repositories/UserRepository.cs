using SaveMate.ApplicationDbContext;
using SaveMate.Models;
using SaveMate.Repositories.IRepository;

namespace SaveMate.Repositories
{
    public class UserRepository(SaveMateDbContext context) : BaseRepository<User>(context), IUserRepository
    {
    }
}
