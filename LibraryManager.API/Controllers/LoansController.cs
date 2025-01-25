using LibraryManager.Application.Models;
using LibraryManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LibraryManagerDbContext _context;
        public LoansController(LibraryManagerDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loan = _context.Loans.FirstOrDefault(l => l.Id == id);
            return Ok(loan);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var loans = _context.Loans.Where(l => !l.IsDeleted).ToList();
            return Ok(loans);

        }

        [HttpPost]
        public IActionResult Post(CreateLoanInputModel model)
        {
            var loan = model.ToEntity();
            _context.Loans.Add(loan);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = loan.Id }, model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var loan = _context.Loans.FirstOrDefault(l => l.Id == id);
            loan.SetAsDeleted();
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/return")]
        public IActionResult Return(int id)
        {
            var loan = _context.Loans.FirstOrDefault(l => l.Id == id);
            loan.Return();
            _context.SaveChanges();
            return NoContent();
        }


    }
}
