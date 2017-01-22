using MVCBiblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBiblioteka.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext libraryDB = new ApplicationDbContext();

        public ActionResult Index()
        {
            var genres = libraryDB.Categories.ToList();

            return View(genres);
        }

        public ActionResult Browse(string genre)
        {
            var genreModel = libraryDB.Categories.Include("Books")
                .Single(g => g.name == genre);

            return View(genreModel);
        }

        public ActionResult Details(int id)
        {
            var album = libraryDB.Books.Find(id);

            return View(album);
        }

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = libraryDB.Categories.ToList();

            return PartialView(genres);
        }
    }
}