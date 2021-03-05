using BusReservationProject.Core.Models;
using BusReservationProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusReservationProject.Data.Repositories
{
    public class TicketRepository : Repository<Tickets>,ITicketRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public TicketRepository(AppDbContext appDbContext):base(appDbContext)
        {

        }

        public async Task<Tickets> GetWithPriceByIdAsync(int id)
        {
            return await _appDbContext.Tickets.Include(x => x.Buses).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
