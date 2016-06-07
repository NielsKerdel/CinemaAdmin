using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using CinemaAdmin.Administration.Models;

namespace CinemaAdmin.Administration.Controllers
{
    public class ChairController : Controller
    {
        private IChairRepository ChairRepo;
        private IScheduleRepository scheduleRepo;
        private ITicketRepository TicketRepo;

        public ChairController(IChairRepository chairRepo, IScheduleRepository scheduleRepoParam, ITicketRepository ticketRepo)
        {
            ChairRepo = chairRepo;
            scheduleRepo = scheduleRepoParam;
            TicketRepo = ticketRepo;
        }

        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult ChairOverview(int scheduleID, int chairs, int totalTickets, int totalRegular, int totalChild, int totalStudent, int totalSenior, int totalPopcorn, int totalLadies, decimal totalPrice)
        {
            ChairViewModel chairmodel = new ChairViewModel();
            chairmodel.chairs = ChairRepo.Chairs.Where(p => p.ScheduleID.hall.Id == scheduleID);
            ViewBag.Chairs = chairs;
            chairmodel.schedule = scheduleRepo.Schedules.FirstOrDefault(s => s.Id == scheduleID);
            chairmodel.chairQuantity = totalTickets;
            chairmodel.regularQuantity = totalRegular;
            chairmodel.childQuantity = totalChild;
            chairmodel.studentQuantity = totalStudent;
            chairmodel.seniorQuantity = totalSenior;
            chairmodel.popcornQuantity = totalPopcorn;
            chairmodel.ladiesQuantity = totalLadies;
            chairmodel.totalPrice = totalPrice;

            ViewBag.ticketResult = false;

            return View("ChairOverview", chairmodel);
        }

        [HttpGet]
        public ActionResult ChangeChair()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeChair(int OrderCode)
        {
            // call view chairs
            // return View("ChairOverview", chairmodel);
            return RedirectToAction("ChairOverlay", "Chair", new { OrderCode = OrderCode } );
        }

        public ViewResult ChairOverlay(int OrderCode)
        {
            // get count chairs by orderid
            int countChairs = TicketRepo.Tickets.Where(p => p.OrderCode == OrderCode).Count();
            int scheduleID = TicketRepo.Tickets.Where(p => p.OrderCode == OrderCode).Select(p => p.ScheduleFK).FirstOrDefault();

            TicketViewModel model = new TicketViewModel();
            model.tickets = TicketRepo.Tickets.Where(p => p.OrderCode == OrderCode);

            // reset chair table reservations
            Ticket deletedTicket = TicketRepo.DeleteTicket(OrderCode);

            ChairViewModel chairmodel = new ChairViewModel();
            chairmodel.chairs = ChairRepo.Chairs.Where(p => p.ScheduleID.hall.Id == scheduleID);
            ViewBag.Chairs = countChairs;
            chairmodel.schedule = scheduleRepo.Schedules.FirstOrDefault(s => s.Id == scheduleID);
            chairmodel.chairQuantity = countChairs;
            chairmodel.regularQuantity = TicketRepo.Tickets.Where(p => p.OrderCode == OrderCode && p.RateFK == 0).Count();
            chairmodel.childQuantity = TicketRepo.Tickets.Where(p => p.OrderCode == OrderCode && p.RateFK == 3).Count();
            chairmodel.studentQuantity = TicketRepo.Tickets.Where(p => p.OrderCode == OrderCode && p.RateFK == 1).Count();
            chairmodel.seniorQuantity = TicketRepo.Tickets.Where(p => p.OrderCode == OrderCode && p.RateFK == 2).Count();
            chairmodel.popcornQuantity = TicketRepo.Tickets.Where(p => p.OrderCode == OrderCode && p.Popcorn == true).Count();
            chairmodel.ladiesQuantity = TicketRepo.Tickets.Where(p => p.OrderCode == OrderCode && p.Ladies == true).Count();
            chairmodel.totalPrice = TicketRepo.Tickets.Where(p => p.OrderCode == OrderCode).Select(p => p.TotalPrice).FirstOrDefault();

            ViewBag.ticketResult = true;

            return View("ChairOverlay", chairmodel);
        }
    }
}