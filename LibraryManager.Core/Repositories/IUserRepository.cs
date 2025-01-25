using LibraryManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
