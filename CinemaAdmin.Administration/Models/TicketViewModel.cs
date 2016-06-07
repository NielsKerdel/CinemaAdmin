using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaAdmin.Domain.Entities;

namespace CinemaAdmin.Administration.Models
{
    public class TicketViewModel
    {
        public IEnumerable<Ticket> tickets { get; set; }

        public IEnumerable<Schedule> schedules { get; set; }

        public IEnumerable<Movie> movies { get; set; }
    }
}