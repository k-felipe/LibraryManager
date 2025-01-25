using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using LibraryManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryManagerDbContext _context;
        public UserRepository(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users
                .Where(u => !u.IsDeleted)
                .ToListAsync();

            return users;
        }

        public async Task<User?> GetById(int id)
        {
            var user = await _context.Users
                .Include(u => u.Loans)
                .FirstOrDefaultAsync(u => !u.IsDeleted && u.Id == id);

            return user;
        }

        public async Task<int> Insert(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
