using LibraryManager.Application.Models;
using LibraryManager.Application.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.BookQueries.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, ResultViewModel<BookViewModel>>
    {
        private readonly IBookRepository _repository;
        public GetBookByIdHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<BookViewModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetById(request.Id);

            var model = BookViewModel.FromEntity(book);

            return ResultViewModel<BookViewModel>.Success(model);
        }
    }
}
