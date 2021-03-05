using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BusReservationProject.WEB.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusReservationProject.WEB.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Server.HttpSys;

namespace BusReservationProject.WEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly TicketApiServiceCs _ticketApiServiceCs;
        private readonly IMapper _mapper;

        public LoginController(IMapper mapper,TicketApiServiceCs ticketApiServiceCs)
        {
            _ticketApiServiceCs = ticketApiServiceCs;
            _mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var response = await _ticketApiServiceCs.Login(loginDto);
            if (response == null)
            {
                return View("Error1");
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(UserDto userDto)
        {
            var response = await _ticketApiServiceCs.AddAsync(userDto);
            if (response == null)
            {
                return View("Error1");
            }
            return RedirectToAction("Index","Home");
        }
    }
}
