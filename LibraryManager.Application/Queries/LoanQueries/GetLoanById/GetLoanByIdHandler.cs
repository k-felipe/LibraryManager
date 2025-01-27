using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.LoanQueries.GetLoanById
{
    public class GetLoanByIdHandler : IRequestHandler<GetLoanByIdQuery, ResultViewModel<LoanViewModel>>
    {
        private readonly ILoanRepository _repository;
        public GetLoanByIdHandler(ILoanRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<LoanViewModel>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _repository.GetById(request.Id);

            var data = LoanViewModel.FromEntity(loan);

            if (loan is null)
                return ResultViewModel<LoanViewModel>.Error("Loan not found.");

            return ResultViewModel<LoanViewModel>.Success(data);
        }
    }
}

