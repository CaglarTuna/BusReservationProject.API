using BusReservationProject.WEB.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BusReservationProject.WEB.ApiServices
{
    public class BookApiService
    {
        private readonly HttpClient _httpClient;

        public BookApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TicketDto> AddAsync(TicketDto ticketDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(ticketDto), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Ticket", stringContent);

            //if (response.IsSuccessStatusCode)
            //{
            //    ticketDto = JsonConvert.DeserializeObject<TicketDto>(await response.Content.ReadAsStringAsync());

            //    return ticketDto;
            //}
            //return null;
            return ticketDto;
        }
    }
}
