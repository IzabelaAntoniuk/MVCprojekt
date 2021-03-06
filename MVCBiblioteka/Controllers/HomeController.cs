﻿using MVCBiblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBiblioteka.Resources;

namespace MVCBiblioteka.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext libraryDB = new ApplicationDbContext();

        [RequireHttps]
        public ActionResult Index()
        {
            //var genres = libraryDB.Categories.ToList();
            var a = libraryDB.Messages.OrderByDescending(b => b.MessageID);

            return View(a.ToList());
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