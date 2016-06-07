using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Concrete
{
    public class EFHallRepository : IHallRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Hall> Halls
        {
            get
            {
                return context.Halls.ToList();
            }
        }
    }
}
