using LibraryManager.Application.Models;
using LibraryManager.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;
        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _repository.GetById(id);

            var model = BookViewModel.FromEntity(book);

            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _repository.GetAll();
            var model = books.Select(BookViewModel.FromEntity).ToList();

            return Ok(model);

        }

        [HttpPost]
        public IActionResult Post(CreateBookInputModel model)
        {
            var book = model.ToEntity();

            _repository.Insert(book);

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateBookInputModel model)
        {
            var book = await _repository.GetById(id);
            book.Update(book.Title, book.Author, book.PublicationYear);
            await _repository.Update(book);
            
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _repository.GetById(id);

            book.SetAsDeleted();

            await _repository.Update(book);
            return NoContent();
        }

    }
}
