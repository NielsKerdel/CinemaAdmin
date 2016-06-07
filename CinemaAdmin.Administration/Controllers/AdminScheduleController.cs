using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaAdmin.Administration.Controllers
{
    public class AdminScheduleController : Controller
    {
        private IScheduleRepository ScheduleRepo;
        private IMovieRepository MovieRepo;
        private IHallRepository HallRepo;
        private IEnumerable<DateTime> date;
        private IEnumerable<int> duration;

        public AdminScheduleController(IScheduleRepository scheduleRepo, IMovieRepository movieRepo, IHallRepository hallRepo)
        {
            ScheduleRepo = scheduleRepo;
            MovieRepo = movieRepo;
            HallRepo = hallRepo;
            date = new List<DateTime>();
            duration = new List<int>();
        }
        public ViewResult ScheduleIndex()
        {
            return View(ScheduleRepo.Schedules);
        }

        public ViewResult ScheduleEdit(int Id)
        {
            Schedule schedule = ScheduleRepo.Schedules.FirstOrDefault(p => p.Id == Id);
            return View(schedule);
        }

        public ViewResult ScheduleCreate()
        {
            return View("ScheduleEdit", new Schedule());
        }

        [HttpPost]
        public ActionResult ScheduleEdit(Schedule schedule)
        {
            if (ModelState.IsValid && MovieRepo.Movies.FirstOrDefault(m => m.Id == schedule.movieFK) != null && HallRepo.Halls.FirstOrDefault(h => h.Id == schedule.hallFK) != null && schedule.Date > DateTime.Today)
            {
                date = ScheduleRepo.Schedules.Select(s => s.Date);
                duration = ScheduleRepo.Schedules.Select(s => s.movie.Duration);
                List<DateTime> date2 = new List<DateTime>();

                int movieDuration = MovieRepo.Movies.Where(m => m.Id == schedule.movieFK).Select(m => m.Duration).FirstOrDefault();

                DateTime endTime = schedule.Date.AddMinutes(Convert.ToInt32(movieDuration + 15));

                for (int i = 0; i < date.Count(); i++)
                {
                    date2.Add(date.ElementAt(i).AddMinutes(Convert.ToInt32(duration.ElementAt(i) + 15)));
                }

                for(int j = 0; j < date.Count(); j++)
                {
                    if(j - 1 > 0)
                    {
                        if (endTime < date.ElementAt(j) && schedule.Date > date2.ElementAt(j - 1))
                        {
                            ScheduleRepo.SaveSchedule(schedule);
                            TempData["message"] = string.Format("{0} has been saved", schedule.Id);
                            return RedirectToAction("ScheduleIndex");
                        }
                    } else
                    {
                        if (endTime < date.ElementAt(j))
                        {
                            ScheduleRepo.SaveSchedule(schedule);
                            TempData["message"] = string.Format("{0} has been saved", schedule.Id);
                            return RedirectToAction("ScheduleIndex");
                        }
                    }
                }            
            }
            else {
                // there is something wrong with the data values
                return View(schedule);
            }
            return View(schedule);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Schedule deletedSchedule = ScheduleRepo.DeleteSchedule(Id);
            if (deletedSchedule != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedSchedule.Id);
            }
            return RedirectToAction("Index");
        }


    }
}