using BusReservationProject.Core.Models;
using BusReservationProject.Core.Repositories;
using BusReservationProject.Core.Services;
using BusReservationProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservationProject.Service.Services
{
    public class SeatService : Service<Seats>,ISeatService
    {
        public SeatService(IUnitOfWork unitOfWork, IRepository<Seats> repository) : base(unitOfWork, repository)
        {

        }
    }
}
