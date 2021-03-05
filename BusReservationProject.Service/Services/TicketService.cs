using BusReservationProject.Core.Models;
using BusReservationProject.Core.Repositories;
using BusReservationProject.Core.Services;
using BusReservationProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusReservationProject.Service.Services
{
    public class TicketService : Service<Tickets>,ITicketService
    {
        public TicketService(IUnitOfWork unitOfWork,IRepository<Tickets> repository) : base(unitOfWork,repository)
        {

        }

        public async Task<Tickets> GetWithPriceByIdAsync(int id)
        {
            return await _unitOfWork.Tickets.GetWithPriceByIdAsync(id);
        }
    }
}
