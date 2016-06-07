using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders;
            }

        }

        public void saveOrder(int OrderNumber, Schedule schedule, Ticket[] ticketsList)
        {
            throw new NotImplementedException();
        }
    }
}
