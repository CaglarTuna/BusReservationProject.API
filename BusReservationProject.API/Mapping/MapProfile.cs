using AutoMapper;
using BusReservationProject.API.DTOs;
using BusReservationProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusReservationProject.API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AppUser, UserDto>();
            CreateMap<UserDto, AppUser>();
            CreateMap<Tickets,TicketDto>();
            CreateMap<TicketDto,Tickets>();
        }
    }
}
