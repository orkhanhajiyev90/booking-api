using AutoMapper;
using BookingApi.Business.Abstract;
using BookingApi.Core.Entities;
using BookingApi.Core.Models.Response;
using BookingApi.Data;
using BookingApi.DataAccess.Repositories.Abstract;

namespace BookingApi.Business.Concrete
{
    public class HomeService : IHomeService
    {
        private readonly IBaseRepository<Home> _repository;
        private readonly IMapper _mapper;

        public HomeService(IBaseRepository<Home> repository, IMapper mapper)
        {
            _repository = repository;
            _repository.AddRange(InMemoryHomeStorage.Homes.Values);
            _mapper = mapper;
        }

        public async Task<BaseListResponse<AvailableHomeResponse>> GetAvailableHomeAsync(DateTime startDate, DateTime endDate)
        {
            var dateRange = new List<DateTime>();
            for (var date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
            {
                dateRange.Add(date);
            }

            var availableHomes = await _repository
                .GetAsync(home => dateRange.All(d => home.AvailableSlots.Contains(d.Date)));

            var response = _mapper.Map<List<AvailableHomeResponse>>(availableHomes);

            foreach (var item in response)
            {
                item.AvailableSlots = item.AvailableSlots
                    .Where(d => d >= startDate && d <= endDate)
                    .ToList();
            }

            return new BaseListResponse<AvailableHomeResponse>(response);
        }
    }
}
