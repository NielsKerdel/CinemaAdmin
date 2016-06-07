using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Entities
{
    public class Row
    {
        public int ID { get; set; }
        [ForeignKey("HallID")]
        public int? HallFK { get; set; }
        public virtual Hall HallID { get; set; }
        public int TotalSeats { get; set; }
    }
}
