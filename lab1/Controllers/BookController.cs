using lab1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab1.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public String HelloTeacher(String university)
        {
            return "Lê Thanh Bình - university" + university;
        }

        public ActionResult ListBooks()
        {
            var books = new List<String>();
            books.Add ("HTML5&CSS the compelete manual - author name book 1");
            books.Add ("HTML5&CSS responsive web - author name book 2");
            books.Add ("professional ASP.NET MVC5 - author name book 3");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5&CSS the compelete manual" ," author name book 1", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "HTML5&CSS responsive web","author name book 2", "/Content/Images/book.jpg"));
            books.Add(new Book(3, "professional ASP.NET MVC5","author name book 3", "/Content/Images/book1.jpg"));
            return View(books);
        }
    
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5&CSS the compelete manual", " author name book 1", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "HTML5&CSS responsive web", "author name book 2", "/Content/Images/book.jpg"));
            books.Add(new Book(3, "professional ASP.NET MVC5", "author name book 3", "/Content/Images/book1.jpg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book==null)
            {
                return HttpNotFound();
            } 
            return View(books);
        }

       [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5&CSS the compelete manual", " author name book 1", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "HTML5&CSS responsive web", "author name book 2", "/Content/Images/book.jpg"));
            books.Add(new Book(3, "professional ASP.NET MVC5", "author name book 3", "/Content/Images/book1.jpg"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_cover = ImageCover;
                    break;
                }
            }

            return View("ListBookModel", books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]

        public ActionResult Contact([Bind(Include = "Id, Title, Author, ImagesCover")] Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5&CSS the compelete manual", " author name book 1", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "HTML5&CSS responsive web", "author name book 2", "/Content/Images/book.jpg"));
            books.Add(new Book(3, "professional ASP.NET MVC5", "author name book 3", "/Content/Images/book1.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch(RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }

    }
}