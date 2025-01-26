using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models
{
    public class BookViewModel
    {
        public BookViewModel(string title, string author, string iSBN, int publicationYear, ICollection<Loan> loans)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
            Loans = loans;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
        public ICollection<Loan> Loans { get; private set; } = [];

        public static BookViewModel FromEntity(Book book)
        {
            if (book is null)
                return null;

            return new BookViewModel(
                book.Title,
                book.Author,
                book.ISBN,
                book.PublicationYear,
                book.Loans
            );
        }
    }
}
