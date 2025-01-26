using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommand : IRequest<ResultViewModel>
    {
        public UpdateBookCommand(int id, string title, string author, int publicationYear)
        {
            Id = id;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int PublicationYear { get; private set; }
    }
}
