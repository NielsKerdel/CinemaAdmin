using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaAdmin.Domain.Entities;

namespace CinemaAdmin.Administration.Models
{
    public class KijkwijzerViewModel
    {
        public Movie movie { get; set; }
        public List<Kijkwijzer> kijkwijzer { get; set; }

    }
}