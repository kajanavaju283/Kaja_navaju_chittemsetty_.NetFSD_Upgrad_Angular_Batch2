using DataAccessLayer.DbContext;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AppUILayer.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;
        private readonly AppDbContext _context;

        public ContactController(IContactRepository repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet("")]
        public IActionResult ShowContacts()
        {
            var data = _repo.GetAllContacts();
            return View(data);
        }

        [HttpGet("add")]
        public IActionResult AddContact()
        {
            ViewBag.Companies = _context.Companies.ToList();
            ViewBag.Departments = _context.Departments.ToList();
            return View();
        }

        [HttpPost("add")]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        //[HttpGet("edit/{id}")]
        //public IActionResult EditContact(int id)
        //{
        //    var contact = _repo.GetContactById(id);

        //    ViewBag.Companies = _context.Companies.ToList();
        //    ViewBag.Department = _context.Departments.ToList();
        //    return View(contact);
        //}
        [HttpGet("edit/{id}")]
        public IActionResult EditContact(int id)
        {
            var contact = _repo.GetContactById(id);

            if (contact == null)
            {
                return NotFound();
            }
            ViewBag.Companies = _context.Companies.ToList();
            ViewBag.Departments = _context.Departments.ToList();

            return View(contact);
        }

        [HttpPost("edit")]
        public IActionResult EditContact(ContactInfo contact)
        {
            _repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }
        [HttpGet("delete/{id}")]
        public IActionResult DeleteContact(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }
    }
            

    }

