using BusReservationProject.Core.Models;
using BusReservationProject.Core.Repositories;
using BusReservationProject.Core.Services;
using BusReservationProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusReservationProject.Service.Services
{
    public class UserService : Service<AppUser>,IUserService
    {
        public UserService(IUnitOfWork unitOfWork,IRepository<AppUser> repository) : base(unitOfWork,repository)
        {

        }
    }
}
