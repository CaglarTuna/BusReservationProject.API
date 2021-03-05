using BusReservationProject.Core.Repositories;
using BusReservationProject.Core.UnitOfWorks;
using BusReservationProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusReservationProject.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private TicketRepository _ticketRepository;
        private UserRepository _userRepository;

        public IUserRepository Products => _userRepository ??= new UserRepository(_context);
        public ITicketRepository Tickets => _ticketRepository ??= new TicketRepository(_context);


        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
