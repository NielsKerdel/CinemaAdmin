using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Concrete
{
    public class EFGenreRepository : IGenreRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Genre> Genres
        {
            get
            {
                return context.Genres.ToList();
            }
        }
    }
}
