using CinemaAdmin.Administration.Models;
using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaAdmin.Administration.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository movieRepo;
        private IKijkwijzerRepository kijkwijzerRepo;
        private IScheduleRepository scheduleRepo;
        private IChairRepository chairRepo;

        public MovieController(IMovieRepository movieRepoParam, IKijkwijzerRepository kijkwijzerRepoParam, IScheduleRepository scheduleRepoParam, IChairRepository chairRepoParam)
        {
            movieRepo = movieRepoParam;
            kijkwijzerRepo = kijkwijzerRepoParam;
            scheduleRepo = scheduleRepoParam;
            chairRepo = chairRepoParam;
        }

        public ViewResult MovieDetails(int movieID = 0)
        {
            Movie movie = movieRepo.Movies.FirstOrDefault(m => m.Id == movieID);
            KijkwijzerViewModel kijkwijzerModel = new KijkwijzerViewModel();

            kijkwijzerModel.movie = movie;
            kijkwijzerModel.kijkwijzer = kijkwijzerRepo.Kijkwijzers.ToList();

            return View("Movie", kijkwijzerModel);
        }

        public ViewResult MovieInfoOverview(int scheduleID = 3)
        {
            ScheduleOverviewModel model = new ScheduleOverviewModel();

            model.schedule = scheduleRepo.Schedules.FirstOrDefault(s => s.Id == scheduleID);

            int movieID = scheduleRepo.Schedules.FirstOrDefault(s => s.Id == scheduleID).movie.Id;
            model.movie = movieRepo.Movies.FirstOrDefault(m => m.Id == movieID);

            model.chairs = chairRepo.Chairs.Where(c => c.ScheduleFK == scheduleID);

            return View("MovieInfoOverview", model);
        }
    }
}