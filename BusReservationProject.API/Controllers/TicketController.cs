using AutoMapper;
using BusReservationProject.API.DTOs;
using BusReservationProject.Core.Models;
using BusReservationProject.Core.Services;
using BusReservationProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BusReservationProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly AppDbContext _context;
        private readonly IUserService _userService;
        private readonly ISeatService _seatService;
        private readonly IBusService _busService;
        private readonly IMapper _mapper;

        public TicketController(ITicketService ticketService, IMapper mapper,IUserService userService,ISeatService seatService,IBusService busService,AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _ticketService = ticketService;
            _userService = userService;
            _seatService = seatService;
            _busService = busService;
        }
        [HttpPost]
        public async Task<IActionResult> BookTicket(TicketDto ticketDto)
        {
            var currentUser = _userService.Where(x => x.Email == ticketDto.Email).Result.First();
            var bookedSeat = _seatService.Where(x => x.SeatNumbers == ticketDto.SeatNumbers).Result.First();
            var bookedBus = _busService.Where(x => x.Plate == ticketDto.Plate).Result.First();
            var count = _ticketService.Where(x => x.Buses.Id == bookedBus.Id).Result.Count();

            if (_ticketService.Where(x=>x.Buses.Plate==ticketDto.Plate).Result.Any() && _ticketService.Where(x => x.Seats.SeatNumbers == ticketDto.SeatNumbers).Result.Any())
            {
                return NotFound("Seat is Taken");
            }

            if ( count ==5 || count == 10 || count == 15 )
            {
                bookedBus.Price *= (decimal)1.1;
                _busService.Update(bookedBus);
            }
            else if(count == 20)
            {
                bookedBus.Price /= (decimal)Math.Pow(1.1 , 3);
                _busService.Update(bookedBus);
            }

            await _ticketService.AddAsync(new Tickets
            {
                Buses = bookedBus,
                Seats = bookedSeat,
                Users = currentUser
            });

            return Created(string.Empty,"ok");
        }
    }
}
