using LibraryAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Data
{
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorEntity>().ToTable("Authors");
            modelBuilder.Entity<AuthorEntity>().HasMany(a => a.Books).WithOne(b => b.Author);
            modelBuilder.Entity<BookEntity>().Property(a => a.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<BookEntity>().ToTable("Books");
            modelBuilder.Entity<BookEntity>().Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<BookEntity>().HasOne(b => b.Author).WithMany(a => a.Books);
        }

        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookEntity> Books { get; set; }

        //dotnet ef migrations add "Initial" -o "Data\Migrations" 
        //dotnet ef database update 
    }
}
