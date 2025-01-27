using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.UpdateLoan
{
    public class UpdateLoanHandler : IRequestHandler<UpdateLoanCommand, ResultViewModel>
    {
        public Task<ResultViewModel> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
