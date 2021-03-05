using BusReservationProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusReservationProject.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ITicketRepository Tickets { get; }
        Task CommitAsync();
        void Commit();
    }
}
