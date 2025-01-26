using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.BookQueries.GetBookById
{
    public class GetBookByIdQuery : IRequest<ResultViewModel<BookViewModel>>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
