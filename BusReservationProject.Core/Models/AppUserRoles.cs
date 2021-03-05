using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusReservationProject.Core.Models
{
    public class AppUserRoles : IdentityRole
    {
        public ICollection<AppUser> User { get; set; }
    }
}
