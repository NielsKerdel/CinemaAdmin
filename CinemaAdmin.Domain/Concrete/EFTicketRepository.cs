using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Concrete
{
    public class EFTicketRepository : ITicketRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Ticket> Tickets
        {
            get
            {
                return context.Tickets.ToList();
            }
        }

        public void SaveTicket(Ticket ticket)
        {
            if (ticket.ID == 0)
            {
                context.Tickets.Add(ticket);
            }
            else {
                Ticket dbEntry = context.Tickets.Find(ticket.ID);
                if (dbEntry != null)
                {
                    dbEntry.ID = ticket.ID;
                    dbEntry.HallFK = ticket.HallFK;
                    dbEntry.MovieFK = ticket.MovieFK;
                    dbEntry.OrderCode = ticket.OrderCode;
                    dbEntry.RateFK = ticket.RateFK;
                    dbEntry.RowFK = ticket.RowFK;
                    dbEntry.ScheduleFK = ticket.ScheduleFK;
                    dbEntry.SeatFK = ticket.SeatFK;
                    dbEntry.Popcorn = ticket.Popcorn;
                    dbEntry.Ladies = ticket.Ladies;
                    dbEntry.TotalPrice = ticket.TotalPrice;
                }
            }
            context.SaveChanges();
        }

        public Ticket DeleteTicket(int orderID)
        {
            Ticket dbEntry = context.Tickets.Find(orderID);
            if (dbEntry != null)
            {
                context.Tickets.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
