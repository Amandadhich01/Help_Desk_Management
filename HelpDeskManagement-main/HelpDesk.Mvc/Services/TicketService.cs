using HelpDesk.Mvc.Models;
using Newtonsoft.Json;
using System.Text;

namespace HelpDesk.Mvc.Services
{
    public class TicketService
    {
        private readonly HttpClient _httpClient;

        public TicketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            var response = await _httpClient.GetAsync("api/Tickets");

            if (!response.IsSuccessStatusCode)
                return new List<Ticket>();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Ticket>>(json)
                   ?? new List<Ticket>();
        }

        public async Task<Ticket?> GetTicketByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Tickets/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Ticket>(json);
        }

        public async Task CreateTicketAsync(Ticket ticket)
        {
            var json = JsonConvert.SerializeObject(ticket);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            await _httpClient.PostAsync("api/Tickets", content);
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            var json = JsonConvert.SerializeObject(ticket);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            await _httpClient.PutAsync($"api/Tickets/{ticket.Id}", content);
        }

        public async Task DeleteTicketAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Tickets/{id}");
        }
    }
}