namespace LibraryManager.API.Controllers
{
    public class UpdateBookInputModel
    {
        public UpdateBookInputModel(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public int PublicationYear { get; private set; }
    }
}