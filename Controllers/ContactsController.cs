using ContactApp.Models;
using ContactApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers
{
    public class ContactsController(IContactService service) : Controller
    {
        private readonly IContactService _service = service;

        public IActionResult Index()
        {
            var contacts = _service.GetContacts();
            return View(contacts);
        }

        public IActionResult Create() => View();

        public IActionResult Edit(int id)
        {
            var contact = _service.GetContactById(id);
            if (contact == null) return NotFound();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);
            _service.Create(contact);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);
            _service.Update(contact);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
