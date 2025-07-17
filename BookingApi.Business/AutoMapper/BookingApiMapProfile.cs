using AutoMapper;
using BookingApi.Core.Entities;
using BookingApi.Core.Models.Response;

namespace BookingApi.AutoMapper
{
    public class BookingApiMapProfile : Profile
    {
        public BookingApiMapProfile()
        {
            CreateMap<Home, AvailableHomeResponse>();
        }
    }
}
