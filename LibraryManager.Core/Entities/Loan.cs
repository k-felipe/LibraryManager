using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int userId, int bookId, DateTime dueDate) : base()
        {
            UserId = userId;
            BookId = bookId;
            LoanDate = DateTime.UtcNow;
            DueDate = dueDate;
            IsCompleted = false;
        }

        public int UserId { get; private set; }
        public User User { get; private set; }
        public int BookId { get; private set; }
        public Book Book { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public bool IsCompleted { get; private set; }

        public void Return()
        {
            ReturnDate = DateTime.UtcNow;
            IsCompleted = true;
        }
    }
}
