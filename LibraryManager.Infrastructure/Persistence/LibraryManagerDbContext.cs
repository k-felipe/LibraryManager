using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Core.Entities;

namespace LibraryManager.Infrastructure.Persistence
{
    public class LibraryManagerDbContext : DbContext
    {
        //criar conexao

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }


    }
}
