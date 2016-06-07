using CinemaAdmin.Administration.Models;
using CinemaAdmin.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaAdmin.Administration.Controllers
{
    public class AvailableChairsController : Controller
    {
        private IChairRepository ChairRepo;
        private IScheduleRepository ScheduleRepo;

        public AvailableChairsController(IChairRepository chairRepo, IScheduleRepository scheduleRepo)
        {
            ChairRepo = chairRepo;
            ScheduleRepo = scheduleRepo;
        }

        // GET: AvailableChairs
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult AvailableSchedules()
        {
            AvailableSchedulesModel model = new AvailableSchedulesModel();
            model.schedules = ScheduleRepo.Schedules.Select(s => s);

            return View(model);
        }

        public ViewResult AvailableChairs(int scheduleID)
        {
            AvailableChairModel model = new AvailableChairModel();
            model.chairs = ChairRepo.Chairs.Where(p => p.ScheduleID.hall.Id == scheduleID);
            return View(model);
        }
    }
}