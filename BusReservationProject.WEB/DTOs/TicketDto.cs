using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusReservationProject.WEB.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int SeatNumbers { get; set; }
        public string Plate { get; set; }
    }
}
