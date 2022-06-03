using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Storage.Entities;

namespace LibraryManager.Data
{
    public class LibraryManagerContext : DbContext
    {
        public LibraryManagerContext (DbContextOptions<LibraryManagerContext> options)
            : base(options)
        {
        }

        public DbSet<LibraryManager.Storage.Entities.Book> Books { get; set; }

        public DbSet<LibraryManager.Storage.Entities.Language> Languages { get; set; }
    }
}
