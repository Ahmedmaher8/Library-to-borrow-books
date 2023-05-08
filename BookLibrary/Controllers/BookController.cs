using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Controllers
{

    public class BookController : Controller
    {
        private BookContext context { get; set; }

        public BookController(BookContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {



            return View(context.Books.ToList());

        }
        public IActionResult Create()
        {



            return View();

        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            context.Books.Add(book);
            context.SaveChanges();

            return RedirectToAction("index");

        }
        public IActionResult Borrowers()
        {

            return View(context.borrowers.ToList());

        }
        public IActionResult Borrower()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Borrower(Borrower borrower)
        {
            if (!ModelState.IsValid)
                return View(borrower);

            context.borrowers.Add(borrower);
            context.SaveChanges();

            return RedirectToAction("Borrowers");

        }


        public IActionResult BorrowBook()
        {
            ViewBag.Books = new SelectList(context.Books.ToList(), "Id", "Name");

            ViewBag.Borrowers = new SelectList(context.borrowers.ToList(), "Id", "Name");
            return View();

        }
        [HttpPost]
        public IActionResult BorrowBook(BorrowBooks borrowBooks)
        {
            ViewBag.Books = new SelectList(context.Books.ToList(), "Id", "Name");

            ViewBag.Borrowers = new SelectList(context.borrowers.ToList(), "Id", "Name");

            var book = context.Books.Where(x => x.Id == borrowBooks.BookID).FirstOrDefault();
            if (borrowBooks.actionType == actionTypeEnum.Borrow && book.NumberOfBooks == book.NumberOfBorroedBooks)
            {
                ViewBag.msg = "there is no exists books to borrow";
                return View();
            }
            else if (borrowBooks.actionType == actionTypeEnum.Return && book.NumberOfBorroedBooks == 0)
            {
                ViewBag.msg = "Number of books completed";
                return View();
            }

            book.NumberOfBorroedBooks= borrowBooks.actionType == actionTypeEnum.Return?
                book.NumberOfBorroedBooks-1:book.NumberOfBorroedBooks + 1;
            context.Entry<Book>(book).State=EntityState.Modified;
            context.borrowBooks.Add(borrowBooks);
            context.SaveChanges();
            ViewBag.msgSuccess = borrowBooks.actionType == actionTypeEnum.Return ? "book has been returned" : "book has been Borrowed";
            return View();

        }
    }
}
