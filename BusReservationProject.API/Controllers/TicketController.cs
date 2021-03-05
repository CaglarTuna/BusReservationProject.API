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
            decimal price = 0;
            var currentUser = _userService.Where(x => x.Email == ticketDto.Email).Result.First();
            var bookedSeat = _seatService.Where(x => x.SeatNumbers == ticketDto.SeatNumbers).Result.First();
            var bookedBus = _busService.Where(x => x.Plate == ticketDto.Plate).Result.First();
            var dest = _context.Buses.Where(x => x.Plate == ticketDto.Plate).Select(x => x.Destinations.Id).FirstOrDefault();
            var count = _ticketService.Where(x => x.Buses.Id == bookedBus.Id).Result.Count();

            if (_ticketService.Where(x => x.Buses.Plate == ticketDto.Plate).Result.Any() && _ticketService.Where(x => x.Seats.SeatNumbers == ticketDto.SeatNumbers).Result.Any())
            {
                return NotFound("Seat is Taken");
            }
            if (dest == 1)
                price = 10;
            else if (dest == 2)
                price = 20;
            else
                price = 30;
            if ((count >= 5 && count < 10) || (count >= 10 && count < 15) || (count >= 15 && count < 20))
            {
                price *= 1.1m;
            }
            else if (count == 20)
            {
                price /= 1.1m;
            }

            await _ticketService.AddAsync(new Tickets
            {
                Price = price,
                Buses = bookedBus,
                Seats = bookedSeat,
                Users = currentUser
            });

            return Created(string.Empty, "ok");
        }
    }
}
