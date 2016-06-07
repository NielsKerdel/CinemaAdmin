using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CinemaAdmin.Domain.Entities
{
    public class Schedule
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Geef een geldige datum")]
        public DateTime Date { get; set; }
        [ForeignKey("movie")]

        [Required(ErrorMessage = "Koppel een geldige film")]
        public int movieFK { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual Movie movie { get; set; }

        [Required(ErrorMessage = "Koppel een geldige zaal")]
        [ForeignKey("hall")]
        public int hallFK { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual Hall hall { get; set; }

        [Required(ErrorMessage = "Geef een geldig aantal stoelen op")]
        public int AvailableSeats { get; set; }

        [Required(ErrorMessage = "Geef op of het onder een feestdag valt")]
        public bool isHoliday { get; set; }
    }
}
