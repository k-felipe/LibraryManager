using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanRepository _repository;
        public LoansController(ILoanRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var loan = await _repository.GetById(id);
            return Ok(loan);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var loans = await _repository.GetAll();
            return Ok(loans);

        }

        [HttpPost]
        public async Task<IActionResult> PostA(CreateLoanInputModel model)
        {
            var loan = model.ToEntity();
            await _repository.Insert(loan);
            return CreatedAtAction(nameof(GetById), new { id = loan.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var loan = await _repository.GetById(id);
            loan.SetAsDeleted();

            await _repository.Update(loan);

            return NoContent();
        }

        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnAsync(int id)
        {
            var loan = await _repository.GetById(id);
            loan.Return();

            await _repository.Update(loan);
            return NoContent();
        }


    }
}
