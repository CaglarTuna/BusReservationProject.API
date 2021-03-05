using System;
using System.Collections.Generic;
using System.Text;

namespace BusReservationProject.Core.Models
{
    public class Buses
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public decimal Price{ get; set; }
        public virtual Destinations Destinations { get; set; }
        public ICollection<Tickets> Tickets { get; set; }

    }
}
