using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.InsertBook
{
    public class InsertBookCommand : IRequest<ResultViewModel<int>>
    {
        public InsertBookCommand(string title, string author, string iSBN, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
        public ICollection<Loan> Loans { get; private set; } = new List<Loan>();

        public Book ToEntity() => new(Title, Author, ISBN, PublicationYear);
    }
}

