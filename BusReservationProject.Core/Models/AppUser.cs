using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;

namespace BusReservationProject.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password{ get; set; }
        public ICollection<Tickets> Tickets { get; set; }
    }
}
