using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace AM.UI.WEB.Controllers
{
    public class TicketController : Controller
    {
        private readonly IServiceTicket serviceTicket;
        private readonly IServiceFlight serviceFlight;
        private readonly IServicePassenger servicePassenger;
        
        
        public TicketController(IServiceTicket serviceTicket, IServiceFlight serviceFlight, IServicePassenger servicePassenger)
        {
            This.serviceTicket = serviceTicket;
            this.serviceFlight = serviceFlight;
            this.servicePassenger = servicePassenger;
        }

        // GET: TicketController
        public ActionResult Index()
        {
            var listTicket = serviceTicket.GetMany().ToList();
            return View(listTicket);
        }

        // GET: TicketController/Details/5
        public ActionResult Details(int? PassengerFK, int? FlightFK, int? TicketNbre)
        {
            if(PassengerFK==null || FlightFK==null || TicketNbre==null)
            {
                return NotFound();
            }
            var ticket = serviceTicket.GetMany().Where(t => t.PassengerFK == PassengerFK && t.FlightFK == FlightFK && )
                if()

           
        }

        // GET: TicketController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            try
            {
                serviceTicket.Add(ticket);
                serviceTicket.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Edit/5
        public ActionResult Edit(int? PassengerFK, int? FlightFK, int? TicketNbre)
        {
            if(PassengerFK == null || FlightFK == null || TicketNbre == null)
            {

            }
            return View();
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
