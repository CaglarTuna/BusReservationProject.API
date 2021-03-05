using BusReservationProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusReservationProject.Core.Services
{
    public interface ITicketService:IService<Tickets>
    {
        Task<Tickets> GetWithPriceByIdAsync(int id);
    }
}
