using ContactApp.Models;
using ContactApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController(IContactService service) : ControllerBase
    {
        private readonly IContactService _service = service;

        //public IActionResult Index()
        //{
        //    var contacts = _service.GetContacts();
        //    return View(contacts);
        //}
        // New GET endpoint
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContacts()
        {
            return Ok(_service.GetContacts());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Contact> GetContactById(int id)
        {
            var contact = _service.GetContactById(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        //public IActionResult Create() => View();
        //[HttpPost]
        //public IActionResult Create(Contact contact)
        //{
        //    if (!ModelState.IsValid) return View(contact);
        //    _service.Create(contact);
        //    return RedirectToAction(nameof(Index));
        //}
        // New Create
        [HttpPost]
        public ActionResult<Contact> Create(Contact contact)
        {
            _service.Create(contact);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.id }, contact);
        }

        //public IActionResult Edit(int id)
        //{
        //    var contact = _service.GetContactById(id);
        //    if (contact == null) return NotFound();
        //    return View(contact);
        //}
        //[HttpPost]
        //public IActionResult Edit(Contact contact)
        //{
        //    if (!ModelState.IsValid) return View(contact);
        //    _service.Update(contact);
        //    return RedirectToAction(nameof(Index));
        //}
        // New Edit
        [HttpPut("{id:int}")]
        public ActionResult<Contact> Edit(int id, Contact contact)
        {
            if (id != contact.id) return BadRequest("ID mismatch");
            _service.Update(contact);
            return NoContent();
        }

        //public IActionResult Delete(int id)
        //{
        //    _service.Delete(id);
        //    return RedirectToAction(nameof(Index));
        //}
        // New Delete
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
