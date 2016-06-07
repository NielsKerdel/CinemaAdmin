using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Concrete
{
    public class EFRateRepository : IRateRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Rate> Rates
        {
            get
            {
                return context.Rates.ToList();
            }
        }
    }
}
