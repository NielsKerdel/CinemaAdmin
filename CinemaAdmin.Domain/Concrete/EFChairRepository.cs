using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Concrete
{
    public class EFChairRepository : IChairRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Chair> Chairs
        {
            get
            {
                return context.Chairs;
            }
        }
    }
}
