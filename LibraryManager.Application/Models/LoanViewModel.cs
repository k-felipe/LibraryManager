using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models
{
    public class LoanViewModel
    {
        public LoanViewModel(int userId, int bookId, DateTime loanDate, DateTime dueDate, DateTime? returnDate, bool isCompleted)
        {
            UserId = userId;
            BookId = bookId;
            LoanDate = loanDate;
            DueDate = dueDate;
            ReturnDate = returnDate;
            IsCompleted = isCompleted;
        }

        public int UserId { get; private set; }
        public User User { get; private set; }
        public int BookId { get; private set; }
        public Book Book { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public bool IsCompleted { get; private set; }

        public static LoanViewModel FromEntity(Loan loan)
        {
            return new LoanViewModel(loan.UserId, loan.BookId, loan.LoanDate, loan.DueDate, loan.ReturnDate, loan.IsCompleted);
        }
    }
}
