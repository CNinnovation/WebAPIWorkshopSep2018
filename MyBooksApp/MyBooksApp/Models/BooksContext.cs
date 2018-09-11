using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksApp.Models
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Title).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Publisher).HasMaxLength(25).IsRequired(false);
        }

        public DbSet<Book> Books { get; set; }
    }
}
