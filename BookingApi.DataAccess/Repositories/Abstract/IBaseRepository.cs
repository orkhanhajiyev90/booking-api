namespace BookingApi.DataAccess.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAsync(Func<T, bool> filter);
        Task<List<T>> GetAllAsync();
        void AddRange(IEnumerable<T> items);
    }
}
