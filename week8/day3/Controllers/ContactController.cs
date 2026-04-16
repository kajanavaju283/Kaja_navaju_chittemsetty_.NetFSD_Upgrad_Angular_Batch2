using Microsoft.AspNetCore.Mvc;
using ContactManagement.API.Models;
using ContactManagement.API.DataAccess;

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repo;

        public ContactsController(IContactRepository repo)
        {
            _repo = repo;
        }

        // GET: api/contacts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repo.GetAllContacts();
            return Ok(data);
        }

        // GET: api/contacts/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _repo.GetContactById(id);

            if (contact == null)
                return NotFound("Contact not found");

            return Ok(contact);
        }

        // POST: api/contacts
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ContactInfo contact)
        {
            if (contact == null)
                return BadRequest("Invalid data");

            if (string.IsNullOrEmpty(contact.FirstName))
                return BadRequest("First Name is required");

            var created = await _repo.AddContact(contact);

            return CreatedAtAction(nameof(GetById),
                new { id = created.ContactId }, created);
        }

        // PUT: api/contacts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactInfo contact)
        {
            if (contact == null)
                return BadRequest("Invalid data");

            var result = await _repo.UpdateContact(id, contact);

            if (!result)
                return NotFound("Contact not found");

            return Ok("Updated successfully");
        }

        // DELETE: api/contacts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteContact(id);

            if (!result)
                return NotFound("Contact not found");

            return Ok("Deleted successfully");
        }
    }
}
