using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Entities
{
    public class Rate
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public decimal Discount { get; set; }
    }
}
