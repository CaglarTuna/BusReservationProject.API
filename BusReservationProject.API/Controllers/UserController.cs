using AutoMapper;
using BusReservationProject.API.DTOs;
using BusReservationProject.Core.Models;
using BusReservationProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusReservationProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserDto usertDto)
        {
            if (_userService.Where(x=>x.Email==usertDto.Email).Result.Any())
            {
                return NotFound();
            }
            var newUser = await _userService.AddAsync(_mapper.Map<AppUser>(usertDto));

            return Created(string.Empty, _mapper.Map<UserDto>(newUser));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Login(string id)
        {
            var existingUser = await _userService.Where(x=>x.Id==id);

            if (existingUser.Any())
            {
                return Ok("abc");
            }

            return BadRequest("error");
        }
    }
}
