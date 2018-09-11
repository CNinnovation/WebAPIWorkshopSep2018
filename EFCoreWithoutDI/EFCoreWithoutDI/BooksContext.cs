using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreWithoutDI
{
    public class BooksContext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=Books3;trusted_connection=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Publisher).HasMaxLength(30).IsRequired();
        }

        public DbSet<Book> Books { get; set; }
    }
}
