using AppDemo.Models;

namespace AppDemo.DataAccess
{
    public class ContactImplementation : IContactRepo<ContactInfo>
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>
        {
             new ContactInfo{ ContactId=1,FirstName="Vasu",LastName="R",CompanyName="Cognizant",EmailId="vasu@gmail.com",MobileNo=123456789,Designation="Trainee Analyst" },
             new ContactInfo{ ContactId=2,FirstName="sunny",LastName="CH",CompanyName="Cognizant",EmailId="suneel@gmail.com",MobileNo=123456789,Designation="Trainee Analyst" },
             new ContactInfo{ ContactId=3,FirstName="Maruthi",LastName="N",CompanyName="wipro",EmailId="maruthi@gmail.com",MobileNo=123456789,Designation="Trainee Analyst" }
        };
        public bool AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
            return true;
        }

        public ContactInfo GetContactById(int id)
        {
            var contact=contacts.FirstOrDefault(con => con.ContactId.Equals(id));
            return contact;
        }

        public List<ContactInfo> ShowContacts()
        {
            return contacts;
        }
    }
}
