using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Persistence
{
    public class LibraryManagerDbContext : DbContext
    {
        public LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(u => u.Id);

                u.HasMany(l => l.Loans)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(b => b.Id);

                b.HasMany(l => l.Loans)
                .WithOne(l => l.Book)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Loan>(l =>
            {
                l.HasKey(l => l.Id);

                l.HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

                l.HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            base.OnModelCreating(modelBuilder);
        }


    }
}
