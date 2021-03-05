using BusReservationProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusReservationProject.Core.Repositories
{
    public interface ITicketRepository : IRepository<Tickets>
    {
        Task<Tickets> GetWithPriceByIdAsync(int id);
    }
}
