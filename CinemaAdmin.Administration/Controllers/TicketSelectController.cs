using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using CinemaAdmin.Administration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaAdmin.Administration.Controllers
{
    public class TicketSelectController : Controller
    {
        private IScheduleRepository scheduleRepo;
        private IMovieRepository movieRepo;
        private ITicketRepository ticketRepo;
        private int currentMovieID;

        public TicketSelectController(IScheduleRepository scheduleRepoParam, IMovieRepository movieRepoParam, ITicketRepository ticketRepoParam)
        {
            scheduleRepo = scheduleRepoParam;
            movieRepo = movieRepoParam;
            ticketRepo = ticketRepoParam;
        }

        public ViewResult TicketSelect(int scheduleID)
        {
            SelectedMovieViewModel model = new SelectedMovieViewModel();
            model.schedule = scheduleRepo.Schedules.FirstOrDefault(x => x.Id == scheduleID);
            currentMovieID = model.schedule.movie.Id;
            model.movie = movieRepo.Movies.FirstOrDefault(x => x.Id == currentMovieID);

            return View("TicketSelect", model);
        }
    }
}