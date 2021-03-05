using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusReservationProject.API.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} field is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} field is required.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "{0} field is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} field is required.")]
        public string Password { get; set; }
    }
}
