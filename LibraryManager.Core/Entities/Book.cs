using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManager.Core.Entities
{
    public class Book : BaseEntity
    {
        protected Book() { }
        public Book(string title, string author, string isbn, int publicationYear) : base()
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
        public ICollection<Loan> Loans { get; private set; } = new List<Loan>();

        public void Update(string title, string author, int publicationYear)
        {
            if (!string.IsNullOrWhiteSpace(title))
                Title = title;

            if (!string.IsNullOrWhiteSpace(author))
                Title = author;

            PublicationYear = publicationYear;
        }


    }
}
