using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Abstract
{
    public interface IRateRepository
    {
        IEnumerable<Rate> Rates { get; }
    }
}
