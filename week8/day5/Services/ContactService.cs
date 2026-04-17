using Microsoft.EntityFrameworkCore;   // ✅ VERY IMPORTANT
using Week8_day5.Data;
using Week8_day5.Exceptions;
using Week8_day5.Models;

namespace Week8_day5.Services   // ✅ FIXED (removed .API)
{
    public class ContactService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ContactService> _logger;

        public ContactService(AppDbContext context, ILogger<ContactService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();   // ✅ NOW WORKS
        }

        public async Task<Contact> GetById(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                throw new NotFoundException("Contact not found");

            return contact;
        }

        public async Task<Contact> Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Contact created: {Name}", contact.Name);

            return contact;
        }

        public async Task<Contact> Update(int id, Contact updated)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                throw new NotFoundException("Contact not found");

            contact.Name = updated.Name;
            contact.Email = updated.Email;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Contact updated: {Id}", id);

            return contact;
        }

        public async Task Delete(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                throw new NotFoundException("Contact not found");

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Contact deleted: {Id}", id);
        }
    }
}
