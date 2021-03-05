using System;
using System.Collections.Generic;
using System.Text;

namespace BusReservationProject.Core.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public virtual AppUser Users { get; set; }
        public virtual Seats Seats{ get; set; }
        public virtual Buses Buses { get; set; }
    }
}
