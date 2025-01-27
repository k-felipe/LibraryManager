using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.ReturnLoan
{
    public class ReturnLoanCommand : IRequest<ResultViewModel>
    {
        public ReturnLoanCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
