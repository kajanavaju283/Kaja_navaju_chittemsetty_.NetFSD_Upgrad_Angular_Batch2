using ContactAPI.Models;

namespace ContactAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private static List<Contact> contacts = new List<Contact>
        {
            new Contact{ ContactId=1, Name="John", Email="john@test.com", Phone="1111111111"},
            new Contact{ ContactId=2, Name="Sara", Email="sara@test.com", Phone="2222222222"},
            new Contact{ ContactId=3, Name="Mike", Email="mike@test.com", Phone="3333333333"},
            new Contact{ ContactId=4, Name="Anna", Email="anna@test.com", Phone="4444444444"},
            new Contact{ ContactId=5, Name="David", Email="david@test.com", Phone="5555555555"},
            new Contact{ ContactId=6, Name="Emma", Email="emma@test.com", Phone="6666666666"}
        };

        public List<Contact> GetAll()
        {
            Console.WriteLine("Fetching from DB...");
            return contacts;
        }

        public Contact GetById(int id)
        {
            Console.WriteLine("Fetching by ID from DB...");
            return contacts.FirstOrDefault(x => x.ContactId == id);
        }
    }
}
