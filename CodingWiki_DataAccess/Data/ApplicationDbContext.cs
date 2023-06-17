using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=WAYNE\\SQLEXPRESS;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var bookList = new Book[]
            {
                new Book { BookId = 1, Title = "Bible", ISBN = "133B12", Price = 10.5m, Publisher_Id=1 },
                new Book { BookId = 2, Title = "ABC", ISBN = "133B15", Price = 9.5m, Publisher_Id=1 }
            };

            var publisherList = new Publisher[]
            {
                new Publisher { Publisher_Id=1, Location="Auckland", Name="Wayne"}
            };

            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new {u.Book_Id, u.Author_Id });
            modelBuilder.Entity<Book>().HasData(bookList);
            modelBuilder.Entity<Publisher>().HasData(publisherList);
        }
    }
}
