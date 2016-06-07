using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaAdmin.Administration.Models
{
    public class AvailableChairModel
    {
        public IEnumerable<Chair> chairs { get; set; }
    }
}