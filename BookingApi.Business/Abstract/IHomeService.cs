using BookingApi.Core.Models.Response;

namespace BookingApi.Business.Abstract
{
    public interface IHomeService
    {
        Task<BaseListResponse<AvailableHomeResponse>> GetAvailableHomeAsync(DateTime startDate, DateTime endDate);
    }
}
