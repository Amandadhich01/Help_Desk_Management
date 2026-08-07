using HelpDesk.Mvc.Models;
using HelpDesk.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Mvc.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketService _ticketService;

        public TicketsController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return View(tickets);
        }

        public async Task<IActionResult> Details(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);

            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            if (!ModelState.IsValid)
                return View(ticket);

            await _ticketService.CreateTicketAsync(ticket);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);

            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Ticket ticket)
        {
            if (!ModelState.IsValid)
                return View(ticket);

            await _ticketService.UpdateTicketAsync(ticket);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);

            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ticketService.DeleteTicketAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}