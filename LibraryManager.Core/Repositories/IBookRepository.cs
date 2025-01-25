using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetById(int id);
        Task<List<Book>> GetAll();
        Task<int> Insert(Book book);
        Task Update(Book book);

    }
}
