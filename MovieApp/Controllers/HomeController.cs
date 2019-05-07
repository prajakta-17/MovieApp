using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDBEntities db = new MoviesDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Id")] Movie MovieToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            db.Movies.Add(MovieToCreate);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var MovieToEdit = (from m in db.Movies
                               where m.Id == id
                               select m).First();
            return View(MovieToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie MovieToEdit)
        {
            var originalMovie = (from m in db.Movies
                                 where m.Id == MovieToEdit.Id
                                 select m).First();

            if (!ModelState.IsValid)
                return View(originalMovie);

            db.Entry(originalMovie).CurrentValues.SetValues(MovieToEdit);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        
    }
}
