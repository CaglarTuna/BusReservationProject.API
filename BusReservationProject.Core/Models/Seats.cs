using System;
using System.Collections.Generic;
using System.Text;

namespace BusReservationProject.Core.Models
{
    public class Seats
    {
        public int Id { get; set; }
        public int SeatNumbers { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
    }
}
