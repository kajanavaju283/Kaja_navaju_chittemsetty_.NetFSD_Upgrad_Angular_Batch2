using ContactAPI.Models;
using ContactAPI.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace ContactAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;
        private readonly IMemoryCache _cache;

        public ContactService(IContactRepository repo, IMemoryCache cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public List<Contact> GetAll()
        {
            string key = "contacts";

            if (!_cache.TryGetValue(key, out List<Contact> data))
            {
                data = _repo.GetAll();
                _cache.Set(key, data, TimeSpan.FromSeconds(60));
            }

            return data;
        }

        public Contact GetById(int id)
        {
            string key = $"contact_{id}";

            if (!_cache.TryGetValue(key, out Contact data))
            {
                data = _repo.GetById(id);
                _cache.Set(key, data, TimeSpan.FromSeconds(60));
            }

            return data;
        }

        public object GetPaged(int pageNumber, int pageSize)
        {
            var data = _repo.GetAll();

            var totalRecords = data.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var result = data
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new
            {
                totalRecords,
                totalPages,
                currentPage = pageNumber,
                pageSize,
                data = result
            };
        }
    }
}
