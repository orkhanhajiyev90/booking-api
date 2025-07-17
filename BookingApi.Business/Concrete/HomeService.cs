using BookingApi.Business.Abstract;
using BookingApi.Business.ExtensionMethods;
using BookingApi.Core.Entities;
using BookingApi.Core.Models.Response;
using BookingApi.Data;
using BookingApi.DataAccess.Repositories.Abstract;

namespace BookingApi.Business.Concrete
{
    public class HomeService : IHomeService
    {
        private readonly IBaseRepository<Home> _repository;
        public HomeService(IBaseRepository<Home> repository)
        {
            _repository = repository;
            _repository.AddRange(InMemoryHomeStorage.Homes.Values);
        }
        public async Task<BaseListResponse<AvailableHomeResponse>> GetAvailableHomeAsync(DateTime startDate, DateTime endDate)
        {
            //Get selected dateRange by DateTimeExtension Method
            var dateRange = startDate.Date.GetDateRange(endDate.Date).ToList();

            //Filtering
            var availableHomes = await _repository
                .GetAsync(home => dateRange.All(date => home.AvailableSlots.Contains(date.Date)));

            //Mapping
            var response = availableHomes
                .Select(home => new AvailableHomeResponse
                {
                    HomeId = home.HomeId,
                    HomeName = home.HomeName,
                    AvailableSlots = home.AvailableSlots
                        .Where(d => d >= startDate.Date && d <= endDate.Date)
                        .ToList()
                })
                .ToList();

            return new BaseListResponse<AvailableHomeResponse>(response);
        }
    }
}
