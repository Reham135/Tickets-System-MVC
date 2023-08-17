using D2Assignment.Models.Domain;
using D2Assignment.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.ServiceBus.Messaging;
using System.Reactive;

namespace D2Assignment.Controllers
{
    public class TicketController : Controller

    {
        private static List<Ticket> _tickets = new();
        public void getviewdata()
        {
            ViewData[Constants.Departments] = Department.GetDepartments()
           .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
           .ToList();
        }
        public void getViewBag()
        {
            ViewBag.Assignees = Developer.GetDevelopers()
            .Select(a => new SelectListItem(a.Fname + " " + a.Lname, a.Id.ToString()))
            .ToList();
        }

        #region GetAllTickets
        public IActionResult Index()
        {
            return View(_tickets);
        }
        #endregion


        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            getviewdata();
            getViewBag();
            return View();
        }
        [HttpPost]
        public IActionResult Add(TicketAddVM ticketVM)
        {
            if (!ModelState.IsValid) { 
            getviewdata();
            getViewBag();
            return View();
            }
            var selectedDept = Department.GetDepartments().First(w => w.Id == ticketVM.DepartmentId);
            var selectedAssignees = Developer.GetDevelopers().Where(a => ticketVM.AssigneesId.Contains(a.Id)).ToList();
            Ticket ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                CreatedDate = ticketVM.CreatedDate,
                IsClosed = ticketVM.IsClosed,
                Description = ticketVM.Description,
                Severity = ticketVM.Severity,
                Department = selectedDept,
                Assignees = selectedAssignees
            };
            _tickets.Add(ticket);
            TempData[Constants.Operation] = Constants.Add;
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Edit

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            getviewdata();
            getViewBag();
            Ticket ticket = _tickets.First(w => w.Id == id);
            TicketEditVM ticketEditVM = new()
            {
                Id = ticket.Id,
                CreatedDate = ticket.CreatedDate,
                IsClosed = ticket.IsClosed,
                Description = ticket.Description,
                Severity = ticket.Severity,
                DepartmentId = ticket.Department.Id,
                AssigneesId = ticket.Assignees.Select(a => a.Id).ToList(),

            };
            return View(ticketEditVM);

        }
        [HttpPost]
        public IActionResult Edit(TicketAddVM ticketVM)

        {
            var selectedDept = Department.GetDepartments().First(w => w.Id == ticketVM.DepartmentId);
            var selectedAssignees = Developer.GetDevelopers().Where(a => ticketVM.AssigneesId.Contains(a.Id)).ToList();
            var ticket = _tickets.First(w => w.Id == ticketVM.Id);
            ticket.Severity = ticketVM.Severity;
            ticket.IsClosed = ticketVM.IsClosed;
            ticket.Description = ticketVM.Description;
            ticket.Department = selectedDept;
            ticket.Assignees = selectedAssignees;
            TempData[Constants.Operation] = Constants.Edit;
            return (RedirectToAction(nameof(Index)));
        }

        #endregion


        #region Delete
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var ticketToRemove = _tickets.First(w => w.Id == id);
            _tickets.Remove(ticketToRemove);
            TempData[Constants.Operation] = Constants.Delete;
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
