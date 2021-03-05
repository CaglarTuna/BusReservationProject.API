using BusReservationProject.API.DTOs;
using BusReservationProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace BusReservationProject.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IBusService _busService;

        public NotFoundFilter(IBusService busService)
        {
            _busService = busService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var bus = await _busService.GetByIdAsync(id);

            if (bus != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 404;
                errorDto.Errors.Add($"There is no bus with {id} id on the database.");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
