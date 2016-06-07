﻿using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaAdmin.Administration.Models
{
    public class ScheduleOverviewModel
    {
        public Schedule schedule { get; set; }
        public Movie movie { get; set; } 
        public IEnumerable<Chair> chairs { get; set; } 
    }
}