using LibraryManager.Application.Models;
using LibraryManager.Application.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.BookQueries.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, ResultViewModel<List<BookViewModel>>>
    {
        private readonly IBookRepository _repository;
        public GetAllBooksHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<BookViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAll();

            var result = books.Select(BookViewModel.FromEntity).ToList();

            return ResultViewModel<List<BookViewModel>>.Success(result);

        }
    }
}
