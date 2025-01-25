using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using LibraryManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryManagerDbContext _context;
        public LoanRepository(LibraryManagerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetAll()
        {
            var loans = await _context.Loans
                .Where(l => !l.IsDeleted)
                .ToListAsync();
            return loans;
        }

        public async Task<Loan?> GetById(int id)
        {
            var loan = await _context.Loans.FirstOrDefaultAsync(l => l.Id == id);
            return loan;
        }

        public async Task<int> Insert(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();

            return loan.Id;
        }

        public async Task Update(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }
    }
}
