using AutoMapper;
using BusReservationProject.WEB.ApiServices;
using BusReservationProject.WEB.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusReservationProject.WEB.Controllers
{
    public class TicketController : Controller
    {
        private readonly BookApiService _bookApiService;
        private readonly IMapper _mapper;

        public TicketController(BookApiService bookApiService,IMapper mapper)
        {
            _mapper = mapper;
            _bookApiService = bookApiService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BookTicket()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BookTicket(TicketDto ticketDto)
        {
            var response = await _bookApiService.AddAsync(ticketDto);

            if (response == null)
            {
                return BadRequest();
            }
            return RedirectToAction("Index","Home");
        }
    }
}
