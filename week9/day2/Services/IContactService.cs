using ContactAPI.Models;

namespace ContactAPI.Services
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        object GetPaged(int pageNumber, int pageSize);
    }
}
