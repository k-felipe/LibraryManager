using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<Loan?> GetById(int id);
        Task<List<Loan>> GetAll();
        Task<int> Insert(Loan loan);
        Task Update(Loan loan);
    }
}
