using BusReservationProject.WEB.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusReservationProject.WEB.ApiServices
{
    public class TicketApiServiceCs
    {
        private readonly HttpClient _httpClient;

        public TicketApiServiceCs(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            IEnumerable<UserDto> userDtos;

            var response = await _httpClient.GetAsync("user");

            if (response.IsSuccessStatusCode)
            {
                userDtos =
                    JsonConvert.DeserializeObject<IEnumerable<UserDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                userDtos = null;
            }

            return userDtos;
        }

        public async Task<UserDto> AddAsync(UserDto userDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("user", stringContent);

            if (response.IsSuccessStatusCode)
            {
                userDto = JsonConvert.DeserializeObject<UserDto>(await response.Content.ReadAsStringAsync());

                return userDto;
            }
            return null;
        }

        public async Task<bool> Update(UserDto userDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("user", stringContent);

            if (response.IsSuccessStatusCode)
            {
                userDto = JsonConvert.DeserializeObject<UserDto>(await response.Content.ReadAsStringAsync());

                return true;
            }
            return false;
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"category/{id}");

            if (response.IsSuccessStatusCode)
            {

                return true;
            }
            return false;
        }
    }
}
