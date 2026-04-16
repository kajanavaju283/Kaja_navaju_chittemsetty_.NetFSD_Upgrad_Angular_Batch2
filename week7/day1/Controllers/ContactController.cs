using AppDemo.Models;
using Microsoft.AspNetCore.Mvc;
using AppDemo.DataAccess;

namespace WebApplication3.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepo<ContactInfo> _contactRepo;

        public ContactController(IContactRepo<ContactInfo> contactRepo)
        {
            this._contactRepo = contactRepo;
        }


        [Route("/")]
        [Route("List",Name ="List")]
        public IActionResult ShowAllContacts()
        {
            var contacts = _contactRepo.ShowContacts();
            return View(contacts);
        }
        
        [Route("GetById/{id?}",Name ="GetById")]
        public IActionResult SearchById(int id)
        {
            var contact=_contactRepo.GetContactById(id);
            if (contact != null)
                return View(contact);
            else return NotFound();
        }

        [Route("AddContact",Name ="AddContact")]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        [Route("SaveData",Name ="SaveData")]
        public IActionResult AddContact(ContactInfo contact)
        {
            var isSaved=_contactRepo.AddContact(contact);
            if (isSaved)
            {
                //return RedirectToAction("ShowAllContacts");
                return RedirectToRoute("List");
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
