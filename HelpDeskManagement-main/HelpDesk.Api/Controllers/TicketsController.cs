using HelpDesk.Api.Interfaces;
using HelpDesk.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _repository;

        public TicketsController(ITicketRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _repository.GetAllTicketsAsync();
            return Ok(tickets);
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var ticket = await _repository.GetTicketByIdAsync(id);

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            await _repository.AddTicketAsync(ticket);

            return CreatedAtAction(
                nameof(GetTicket),
                new { id = ticket.Id },
                ticket);
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
                return BadRequest();

            await _repository.UpdateTicketAsync(ticket);

            return NoContent();
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await _repository.DeleteTicketAsync(id);

            return NoContent();
        }
    }
}