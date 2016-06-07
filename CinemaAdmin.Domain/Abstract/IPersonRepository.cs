using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Abstract
{
    public interface IPersonRepository
    {
        IEnumerable<Person> persons { get; }
    }
}
