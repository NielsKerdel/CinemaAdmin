using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Concrete
{
    public class EFLocationRepository : ILocationRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Location> Locations
        {
            get
            {
                return context.Locations.ToList();
            }
        }
    }
}
