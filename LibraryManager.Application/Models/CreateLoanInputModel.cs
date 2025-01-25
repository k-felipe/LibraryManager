using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models
{
    public class CreateLoanInputModel
    {
        public CreateLoanInputModel(int userId, int bookId, DateTime dueDate)
        {
            UserId = userId;
            BookId = bookId;
            LoanDate = DateTime.UtcNow;
            DueDate = dueDate;
            IsCompleted = false;
        }

        public int UserId { get; private set; }
        public int BookId { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public bool IsCompleted { get; private set; }

        public Loan ToEntity() => new(UserId, BookId, DueDate);
    }
}
