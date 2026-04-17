using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ContactAPI.Models;

namespace ContactAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContactController : ControllerBase
    {
        static List<Contact> contacts = new();

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetAll() => Ok(contacts);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var c = contacts.FirstOrDefault(x => x.ContactId == id);
            return Ok(c);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Contact contact)
        {
            contacts.Add(contact);
            return Ok(contact);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, Contact contact)
        {
            var c = contacts.FirstOrDefault(x => x.ContactId == id);
            if (c == null) return NotFound();

            c.Name = contact.Name;
            c.Email = contact.Email;
            c.Phone = contact.Phone;

            return Ok(c);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var c = contacts.FirstOrDefault(x => x.ContactId == id);
            if (c == null) return NotFound();

            contacts.Remove(c);
            return Ok();
        }
    }
}
