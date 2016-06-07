using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Concrete
{
    public class EFScheduleRepository : IScheduleRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Schedule> Schedules
        {
            get
            {
                return context.Schedules.ToList();
            }
        }

        public void SaveSchedule(Schedule schedule)
        {
            if (schedule.Id == 0)
            {
                context.Schedules.Add(schedule);
            }
            else {
                Schedule dbEntry = context.Schedules.Find(schedule.Id);
                if (dbEntry != null)
                {
                    dbEntry.AvailableSeats = schedule.AvailableSeats;
                    dbEntry.Date = schedule.Date;
                    dbEntry.isHoliday = schedule.isHoliday;
                    dbEntry.movieFK = schedule.movieFK;
                    dbEntry.hallFK = schedule.hallFK;
                }
            }
            context.SaveChanges();
        }

        public Schedule DeleteSchedule(int Id)
        {
            Schedule dbEntry = context.Schedules.Find(Id);
            if (dbEntry != null)
            {
                context.Schedules.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
