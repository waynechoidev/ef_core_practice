// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

//using(ApplicationDbContext context = new())
//{
//    context.Database.EnsureCreated();
//    if(context.Database.GetPendingMigrations().Count()>0)
//    {
//        context.Database.Migrate();
//    }
//}

//AddBook();
//GetAllBooks();
//GetBook();
//GetFiltredBookList();
//GetFiltredBook();
//GetBookById();
//GetBooksByTitle();
//GetPage(2, 2);
//await UpdateBook();
await DeleteBook();

async Task DeleteBook()
{
    using var context = new ApplicationDbContext();
    var book = await context.Books.FindAsync(5);
    context.Books.Remove(book);
    await context.SaveChangesAsync();
}

async Task UpdateBook()
{
    using var context = new ApplicationDbContext();
    var book = await context.Books.FindAsync(2);
    book.Title = "ABCDF";
    await context.SaveChangesAsync();
}

void GetPage(int NumInPage, int Idx)
{
    using var context = new ApplicationDbContext();
    var books = context.Books.Skip(NumInPage * (Idx - 1)).Take(NumInPage);
    foreach (var book in books)
        Console.WriteLine(book.Title + " - " + book.ISBN);
}

void GetBooksByTitle()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.Where(u => u.Title.Contains("AB"));
    //var books = context.Books.Where(u => EF.Functions.Like(u.Title,"%AB%"));
    foreach (var book in books)
        Console.WriteLine(book.Title + " - " + book.ISBN);
}

void GetBookById()
{
    using var context = new ApplicationDbContext();
    var book = context.Books.Find(2);
    Console.WriteLine(book.Title);
}

void GetFiltredBook()
{
    using var context = new ApplicationDbContext();
    var book = context.Books.SingleOrDefault(u => u.Title == "ABC");
    Console.WriteLine(book.Title);
}

void GetFiltredBookList()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.Where(u => u.Publisher_Id == 1 && u.Price >= 10);
    foreach (var book in books)
        Console.WriteLine(book.Title + " - " + book.ISBN);
}

void GetBook()
{
    try
    {
        using var context = new ApplicationDbContext();
        var book = context.Book_fluent.FirstOrDefault();
        if(book != null) Console.WriteLine(book.Title + " - " + book.ISBN);
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void GetAllBooks()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.OrderBy(u=>u.Price).ThenBy(u=>u.ISBN);

    foreach (var book in books)
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }

}

void AddBook()
{
    Book book = new() { Title="New Book", ISBN="123412", Price=12.53m, Publisher_Id=2 };
    using var context = new ApplicationDbContext();
    var books = context.Books.Add(book);
    context.SaveChanges();
}