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
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return NoContent();

        }

        [HttpPost]
        public IActionResult Post()
        {
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put()
        {
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return NoContent();
        }

    }
}
