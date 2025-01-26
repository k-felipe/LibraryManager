using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<List<User>> GetAll();
        Task<int> Insert(User user);
        Task Update(User user);
    }
}
