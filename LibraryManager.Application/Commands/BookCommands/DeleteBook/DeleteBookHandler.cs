﻿using LibraryManager.Application.Models;
using LibraryManager.Application.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
    {
        private readonly IBookRepository _repository;
        public DeleteBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetById(request.Id);
            if (book == null)
                ResultViewModel<BookViewModel>.Error("Book not found.");

            book.SetAsDeleted();
            await _repository.Update(book);

            return ResultViewModel.Success();
        }
    }
}
