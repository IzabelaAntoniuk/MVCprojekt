using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCBiblioteka.Models;

namespace MVCBiblioteka.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books
        public ActionResult Index(string searchTitle, string option, string searchState, string searchCategory)
        {
            var books = db.Books.ToList();
            var state = from m in db.BookStates select m;
            ViewBag.stockLevel = new SelectList(db.Books, "BookStateID", "stockLevel");

            if (option == "title")
            {
                books = books.Where(g => g.title.Contains(searchTitle)).ToList();
            }
            else if (option == "ISBN")
            {
                books = books.Where(g => g.ISBN.Contains(searchTitle)).ToList();

            }
            else if (option == "BookStateID")
            {
                books = books.Where(g => g.BookState.state.Contains(searchTitle)).ToList();

            }
            else if (option == "description")
            {
                books = books.Where(g => g.description.Contains(searchTitle)).ToList();

            }


            return View(books);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "stockLevel")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.stockLevel = new SelectList(db.Books, "BookStateID", "stockLevel");

            return View(book);
        }

        public ActionResult ShowNews()
        {
            var books = db.Books.OrderByDescending(x => x.BookID).Take(3).ToList();

            return View(books);
        }
        public ActionResult Browse(string books)
        {
            var bookModel = db.Books.Include("Books")
                .Single(a => a.title == books);

            return View(bookModel);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "name");
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "name");
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "allname");
            ViewBag.BookStateID = new SelectList(db.BookStates, "BookStateID", "state");

            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,title,premiereDate,PublisherID,AuthorID,CategoryID,description,BookStateID,ISBN,stockLevel")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);

                CategoryBooks CategoryBook = new CategoryBooks();
                CategoryBook.BookID = book.BookID;
                CategoryBook.CategoryID = book.CategoryID;
                db.CategoryBooks.Add(CategoryBook);

                PublisherBooks PublisherBooks = new PublisherBooks();
                PublisherBooks.BookID = book.BookID;
                PublisherBooks.PublisherID = book.PublisherID;
                db.PublisherBooks.Add(PublisherBooks);

                AuthorBooks AuthorBooks = new AuthorBooks();
                AuthorBooks.BookID = book.BookID;
                AuthorBooks.AuthorID = book.AuthorID;
                db.AuthorBooks.Add(AuthorBooks);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "name", book.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "name", book.PublisherID);
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "allname", book.AuthorID);
            ViewBag.BookStateID = new SelectList(db.BookStates, "BookStateID", "state");

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "name");
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "name");
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "allname");
            ViewBag.BookStateID = new SelectList(db.BookStates, "BookStateID", "state");


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookStateID = new SelectList(db.BookStates, "BookStateID", "state", book.BookStateID);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,title,premiereDate,PublisherID,AuthorID,CategoryID,description,BookStateID,ISBN,stockLevel")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;

                CategoryBooks CategoryBook = new CategoryBooks();
                CategoryBook.BookID = book.BookID;
                CategoryBook.CategoryID = book.CategoryID;
                db.CategoryBooks.Add(CategoryBook);

                PublisherBooks PublisherBooks = new PublisherBooks();
                PublisherBooks.BookID = book.BookID;
                PublisherBooks.PublisherID = book.PublisherID;
                db.PublisherBooks.Add(PublisherBooks);

                AuthorBooks AuthorBooks = new AuthorBooks();
                AuthorBooks.BookID = book.BookID;
                AuthorBooks.AuthorID = book.AuthorID;
                db.AuthorBooks.Add(AuthorBooks);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "name", book.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "name", book.PublisherID);
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "allname", book.AuthorID);
            ViewBag.BookStateID = new SelectList(db.BookStates, "BookStateID", "state");
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
