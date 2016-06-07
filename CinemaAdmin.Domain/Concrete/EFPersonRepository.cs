using CinemaAdmin.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Concrete
{
    public class EFPersonRepository : IPersonRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Person> persons
        {
            get
            {
                return context.Persons;
            }
        }
    }
}
