using LibraryManager.Application.Commands.LoanCommands.DeleteLoan;
using LibraryManager.Application.Commands.LoanCommands.InsertLoan;
using LibraryManager.Application.Commands.LoanCommands.ReturnLoan;
using LibraryManager.Application.Queries.LoanQueries.GetAllLoans;
using LibraryManager.Application.Queries.LoanQueries.GetLoanById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetLoanByIdQuery(id));
            return Ok(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllLoansQuery());

            return Ok(result.Data);

        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertLoanCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteLoanCommand(id));
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnAsync(int id)
        {
            var result = await _mediator.Send(new ReturnLoanCommand(id));
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }


    }
}
