using LibraryManager.Application.Repositories;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryManagerDbContext _context;
        public BookRepository(LibraryManagerDbContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetById(int id)
        {
            return await _context.Books
              .SingleOrDefaultAsync(b => b.Id == id);

        }

        public async Task<int> Insert(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task Update(Book book)
        {

            _context.Update(book);
            await _context.SaveChangesAsync();

        }
    }
}
