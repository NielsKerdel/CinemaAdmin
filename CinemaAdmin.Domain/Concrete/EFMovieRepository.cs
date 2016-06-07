using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Concrete
{
    public class EFMovieRepository : IMovieRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Movie> Movies
        {

            get
            {
                return context.Movies;
            }
        }

        public void SaveMovie(Movie movie)
        {
            if (movie.Id == 0)
            {
                context.Movies.Add(movie);
            }
            else {
                Movie dbEntry = context.Movies.Find(movie.Id);
                if (dbEntry != null)
                {
                    dbEntry.Id = movie.Id;
                    dbEntry.Name = movie.Name;
                    dbEntry.Description = movie.Description;
                    dbEntry.Language = movie.Language;
                    dbEntry.Subtitle = movie.Subtitle;
                    dbEntry.Writer = movie.Writer;
                    dbEntry.Stars = movie.Stars;
                    dbEntry.Website = movie.Website;
                    dbEntry.IMDB = movie.IMDB;
                    dbEntry.Trailer = movie.Trailer;
                    dbEntry.Kijkwijzer = movie.Kijkwijzer;
                    dbEntry.ImageData = movie.ImageData;
                    dbEntry.ThumbnailData = movie.ThumbnailData;
                    dbEntry.Type = movie.Type;
                }
            }
            context.SaveChanges();
        }

        public Movie DeleteMovie(int Id)
        {
            Movie dbEntry = context.Movies.Find(Id);
            if (dbEntry != null)
            {
                context.Movies.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
