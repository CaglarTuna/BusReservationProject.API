using BusReservationProject.Core.Models;
using BusReservationProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusReservationProject.Data.Repositories
{
    public class UserRepository : Repository<AppUser>,IUserRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
