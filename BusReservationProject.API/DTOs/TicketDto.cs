using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusReservationProject.API.DTOs
{
    public class TicketDto
    {
        public string Email { get; set; }
        public int SeatNumbers { get; set; }
        public string Plate { get; set; }
    }
}
