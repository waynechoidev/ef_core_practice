using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using CodingWiki_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class BookController : Controller
    {
        public readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Book> objList = _db.Books.Include(u => u.Publisher)
                .Include(u=>u.BookAuthor).ThenInclude(u=>u.Author).ToList();
            //List<Book> objList = _db.Books.Include(u => u.Publisher).ToList();
            //List<Book> objList = _db.Books.ToList();

            //foreach (var obj in objList)
            //{
            //    //obj.Publisher = _db.Publishers.Find(obj.Publisher_Id);
            //    _db.Entry(obj).Reference(u => u.Publisher).Load();
            //    _db.Entry(obj).Collection(u => u.BookAuthor).Load();
            //    foreach(var bookAuth in obj.BookAuthor)
            //    {
            //        _db.Entry(bookAuth).Reference(u => u.Author).Load();
            //        _db.Entry(bookAuth).Reference(u => u.Book).Load();
            //    }
            //}

            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM obj = new();

            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            }
            ); 

            if (id == null || id == 0)
            {
                return View(obj);
            }
            obj.Book = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM obj)
        {
                if (obj.Book.Book_Id == 0)
                {
                    await _db.Books.AddAsync(obj.Book);
                }
                else
                {
                    _db.Books.Update(obj.Book);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Book obj = new();
            obj = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Books.Remove(obj);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            BookDetail obj = new();

            obj = _db.BookDetails.Include(u=>u.Book).FirstOrDefault(u => u.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetail obj)
        {
            if (obj.BookDetail_Id == 0)
            {
                await _db.BookDetails.AddAsync(obj);
            }
            else
            {
                _db.BookDetails.Update(obj);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int id)
        {
            BookAuthorVM obj = new()
            {
                BookAuthorList = _db.BookAuthor.Include(u => u.Author).Include(u => u.Book)
                .Where(u => u.Book_Id == id).ToList(),
                BookAuthor = new()
                {
                    Book_Id = id
                },
                Book = _db.Books.FirstOrDefault(u => u.Book_Id == id)
            };

            List<int> tempListOfAssignedAuthor = obj.BookAuthorList.Select(u => u.Author_Id).ToList();

            //not in clause
            //get all the authors whos id is not in tempListOfAssignedAuthors

            var tempList = _db.Authors.Where(u => !tempListOfAssignedAuthor.Contains(u.Author_Id)).ToList();
            obj.AuthorList = tempList.Select(i => new SelectListItem
            {
                Text = i.FullName,
                Value = i.Author_Id.ToString()
            });

            return View(obj);
        }

        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVM bookAuthorVM)
        {
            if(bookAuthorVM.BookAuthor.Book_Id !=0 && bookAuthorVM.BookAuthor.Author_Id!=0)
            {
                _db.BookAuthor.Add(bookAuthorVM.BookAuthor);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookAuthorVM.BookAuthor.Book_Id });
        }

        public IActionResult RemoveAuthors(int authorId,BookAuthorVM bookAuthorVM)
        {
            int bookId = bookAuthorVM.Book.Book_Id;
            BookAuthor bookAuthor = _db.BookAuthor.FirstOrDefault(
                u => u.Author_Id == authorId && u.Book_Id == bookId);
            
                _db.BookAuthor.Remove(bookAuthor);
                _db.SaveChanges();
            
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });
        }

        public async Task<IActionResult> Playground()
        {
            var BookDetails1 = _db.BookDetails.Include(b=>b.Book).FirstOrDefault(b=>b.BookDetail_Id==4);
            BookDetails1.NumberOfChapters = 2222;
            BookDetails1.Book.Price = 222;
            _db.BookDetails.Update(BookDetails1);
            _db.SaveChanges();

            var BookDetails2 = _db.BookDetails.Include(b => b.Book).FirstOrDefault(b => b.BookDetail_Id == 4);
            BookDetails2.NumberOfChapters = 1111;
            BookDetails2.Book.Price = 111;
            _db.BookDetails.Attach(BookDetails2);
            _db.SaveChanges();

            //IEnumerable<Book> BookList1 = _db.Books;
            //var FilteredBook1 = BookList1.Where(b=>b.Price>50).ToList();
            //var FilteredBook1_1 = BookList1.Where(b => b.Price > 10).ToList();

            //IQueryable<Book> BookList2 = _db.Books;
            //var FilteredBook2 = BookList2.Where(b => b.Price > 50).ToList();
            //var FilteredBook2_1 = BookList2.Where(b => b.Price > 10).ToList();

            //List<Book> BookList3 = _db.Books.Where(b=>b.Price>50).ToList();

            //var bookTemp = _db.Books.FirstOrDefault();
            //bookTemp.Price = 100;

            //var bookCollection = _db.Books;
            //decimal totalPrice = 0;

            //foreach (var book in bookCollection)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookList = _db.Books.ToList();
            //foreach (var book in bookList)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookCollection2 = _db.Books;
            //var bookCount1 = bookCollection2.Count();

            //var bookCount2 = _db.Books.Count();

            return RedirectToAction(nameof(Index));
        }
    }
}
