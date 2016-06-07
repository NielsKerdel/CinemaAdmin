using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaAdmin.Administration.Models
{
    public class AvailableSchedulesModel
    {
        public IEnumerable<Schedule> schedules { get; set; }
    }
}