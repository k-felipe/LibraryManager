using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController :ControllerBase
    {
        private readonly LibraryManagerDbContext _context;
        public BooksController(LibraryManagerDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            return Ok(book);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = _context.Books.ToList();

            return Ok(books);

        }

        [HttpPost]
        public IActionResult Post(CreateBookInputModel model)
        {
            var book = model.ToEntity();

            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new {id = book.Id}, model);
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateBookInputModel model)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            book.Update(model.Title, model.Author, model.PublicationYear);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            book.SetAsDeleted();

            _context.SaveChanges();
            return NoContent();
        }

    }
}
