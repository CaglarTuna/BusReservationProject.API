using AutoMapper;
using BusReservationProject.API.DTOs;
using BusReservationProject.Core.Models;
using BusReservationProject.Core.Services;
using BusReservationProject.Data;
using BusReservationProject.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusReservationProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AdminController(ITicketService ticketService, AppDbContext context,IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
            _context = context;
        }

        public IActionResult List()
        {
            var report = from t in _context.Tickets
                         join b in _context.Buses on t.Buses.Id equals b.Id
                         join u in _context.Users on t.Users.Id equals u.Id
                         select new
                         {
                             u.Name,
                             u.Surname,
                             t.Seats.SeatNumbers,
                             b.Destinations.Destination,
                             b.Price
                         };

            return Ok(report.ToList());
        }
    }
}
