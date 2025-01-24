using LibraryManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController :ControllerBase
    {
        private readonly LibraryManagerDbContext _context;
        public LoansController(LibraryManagerDbContext context)
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
        [HttpPut("{id}/start")]

        public IActionResult Start()
        {
            return NoContent();
        }

        [HttpPut("{id}/return")]
        public IActionResult Return()
        {
            return NoContent();
        }


    }
}
