using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.LoanQueries.GetLoanById
{
    public class GetLoanByIdQuery : IRequest<ResultViewModel<LoanViewModel>>
    {
        public int Id { get; private set; }

        public GetLoanByIdQuery(int id)
        {
            Id = id;
        }
    }
}
