using ContactManagement.API.Models;
using System.Linq;                 // ✅ REQUIRED
using System.Collections.Generic; // ✅ REQUIRED
using System.Threading.Tasks;     // ✅ REQUIRED

namespace ContactManagement.API.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        // Static list (IN-MEMORY STORAGE)
        public static List<ContactInfo> contacts = new List<ContactInfo>();

        private static int nextId = 1;

        // GET ALL
        public async Task<List<ContactInfo>> GetAllContacts()
        {
            return await Task.FromResult(contacts);
        }

        // GET BY ID
        public async Task<ContactInfo?> GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return await Task.FromResult(contact);
        }

        // ADD
        public async Task<ContactInfo> AddContact(ContactInfo contact)
        {
            contact.ContactId = nextId++;
            contacts.Add(contact);

            return await Task.FromResult(contact);
        }

        // UPDATE
        public async Task<bool> UpdateContact(int id, ContactInfo contact)
        {
            var existing = contacts.FirstOrDefault(c => c.ContactId == id);

            if (existing == null)
                return await Task.FromResult(false);

            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.EmailId = contact.EmailId;
            existing.MobileNo = contact.MobileNo;
            existing.Designation = contact.Designation;
            existing.CompanyId = contact.CompanyId;
            existing.DepartmentId = contact.DepartmentId;

            return await Task.FromResult(true);
        }

        // DELETE
        public async Task<bool> DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
                return await Task.FromResult(false);

            contacts.Remove(contact);

            return await Task.FromResult(true);
        }
    }
}
