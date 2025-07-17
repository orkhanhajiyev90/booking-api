using BookingApi.Core.Entities;
using BookingApi.DataAccess.Repositories.Abstract;

namespace BookingApi.Tests
{
    public class FakeHomeRepository : IBaseRepository<Home>
    {
        private readonly List<Home> _homes = new();
        public void AddRange(IEnumerable<Home> homes)
        {
            _homes.AddRange(homes);
        }
        public Task<List<Home>> GetAllAsync()
        {
            return Task.FromResult(_homes.ToList());
        }
        public Task<List<Home>> GetAsync(Func<Home, bool> filter)
        {
            var result = _homes.Where(filter).ToList();
            return Task.FromResult(result);
        }
    }
}
