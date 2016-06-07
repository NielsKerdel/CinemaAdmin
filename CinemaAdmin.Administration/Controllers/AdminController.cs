using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaAdmin.Administration.Controllers
{
    public class AdminController : Controller
    {
        private IMovieRepository MovieRepo;
        public AdminController(IMovieRepository movieRepo)
        {
            MovieRepo = movieRepo;
        }
        public ViewResult Index()
        {
            return View(MovieRepo.Movies);
        }

        public ViewResult Edit(int Id)
        {
            Movie movie = MovieRepo.Movies.FirstOrDefault(p => p.Id ==Id);
            return View(movie);
        }

        public ViewResult Create()
        {
            return View("Edit", new Movie());
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                MovieRepo.SaveMovie(movie);
                TempData["message"] = string.Format("{0} has been saved", movie.Name);
                return RedirectToAction("Index");
            }
            else {
                // there is something wrong with the data values
                return View(movie);
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Movie deletedMovie = MovieRepo.DeleteMovie(Id);
            if (deletedMovie != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedMovie.Name);
            }
            return RedirectToAction("Index");
        }


    }
}