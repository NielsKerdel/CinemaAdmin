using CinemaAdmin.Administration.Models;
using CinemaAdmin.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Globalization;

namespace CinemaAdmin.Administration.Controllers
{
    public class OccupationController : Controller
    {
        private IScheduleRepository ScheduleRepo;
        private IChairRepository ChairRepo;
        IFormatProvider provider;

        public OccupationController(IScheduleRepository scheduleRepo, IChairRepository chairRepo)
        {
            ScheduleRepo = scheduleRepo;
            ChairRepo = chairRepo;
            provider = new CultureInfo("nl-NL");
        }

        // GET: Occupation
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public  ActionResult OccupationView()
        {

            return View();
        }

        [HttpPost]
        public ActionResult OccupationView(int iets = 0)
        {
            string dateInput = Request.Form["date1"];
            DateTime beginDate = new DateTime(00-00-0000);
            DateTime endDate = new DateTime(00 - 00 - 0000);

            if (dateInput.Equals("") == false)
            {
                beginDate = DateTime.ParseExact(dateInput, "yyyy/MM/dd", provider);
            }

            string dateInput2 = Request.Form["date2"];

            if (dateInput2.Equals("") == false)
            {
                endDate = DateTime.ParseExact(dateInput2, "yyyy/MM/dd", provider);
            }
           
            OccupationModel model = new OccupationModel();

            model.movies = ChairRepo.Chairs.Where(c => c.ScheduleID.Date >= beginDate && c.ScheduleID.Date <= endDate && c.Reservation == 2).OrderBy(c => c.ScheduleID.movie.Name).GroupBy(c => c.ScheduleID.movie.Name).Select(c => c.Key).ToList();
            model.countMovie = ChairRepo.Chairs.Where(c => c.ScheduleID.Date >= beginDate && c.ScheduleID.Date <= endDate && c.Reservation == 2).OrderBy(c => c.ScheduleID.movie.Name).GroupBy(c => c.ScheduleID.movie.Name).Select(c => c.Count()).ToList();

            model.halls = ChairRepo.Chairs.Where(c => c.ScheduleID.Date >= beginDate && c.ScheduleID.Date <= endDate && c.Reservation == 2).OrderBy(c => c.ScheduleID.hall.Name).GroupBy(c => c.ScheduleID.hall.Name).Select(c => c.Key).ToList();
            model.countHall = ChairRepo.Chairs.Where(c => c.ScheduleID.Date >= beginDate && c.ScheduleID.Date <= endDate && c.Reservation == 2).OrderBy(c => c.ScheduleID.hall.Name).GroupBy(c => c.ScheduleID.hall.Name).Select(c => c.Count()).ToList();
            return View("OccupationResults", model);
        }
    }
}