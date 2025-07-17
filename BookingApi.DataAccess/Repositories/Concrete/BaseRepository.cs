using BookingApi.DataAccess.Repositories.Abstract;

namespace BookingApi.Core.Repository.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly List<T> _items = new();

        public void AddRange(IEnumerable<T> items)
        {
            _items.AddRange(items);
        }

        public Task<List<T>> GetAllAsync()
        {
            return Task.FromResult(_items.ToList());
        }

        public Task<List<T>> GetAsync(Func<T, bool> filter)
        {
            var result = _items.Where(filter).ToList();
            return Task.FromResult(result);
        }
    }
}
