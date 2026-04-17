using ContactAPI.Models;

namespace ContactAPI.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
    }
}
