using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAdmin.Domain.Entities
{
    public class Account
    {
        public int ID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

        public String Type { get; set; }

        [ForeignKey("PersonID")]
        public int? PersonFK { get; set; }
        public virtual Person PersonID { get; set; }

    }
}
