using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaAdmin.Administration.Models
{
    public class OccupationModel
    {
        public IEnumerable<String> movies { get; set; }
        public IEnumerable<int> countMovie { get; set; }
        public IEnumerable<String> halls { get; set; }
        public IEnumerable<int> countHall { get; set; }
    }
}