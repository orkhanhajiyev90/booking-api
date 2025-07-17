using Xunit;
using Moq;
using AutoMapper;
using BookingApi.Business.Concrete;
using BookingApi.Core.Entities;
using BookingApi.Core.Models.Response;
using BookingApi.DataAccess.Repositories.Abstract;

namespace BookingApi.Tests
{
    public class AvailableHomeTests
    {
        private readonly Mock<IBaseRepository<Home>> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly HomeService _homeService;

        public AvailableHomeTests()
        {
            _repositoryMock = new Mock<IBaseRepository<Home>>();
            _mapperMock = new Mock<IMapper>();
            _homeService = new HomeService(_repositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAvailableHomeAsync_ReturnsCorrectHomes()
        {
            var startDate = new DateTime(2025, 7, 20);
            var endDate = new DateTime(2025, 7, 21);
            var dateRange = new List<DateTime> { startDate, endDate };

            var homes = new List<Home>
        {
            new Home
            {
                HomeId = "1",
                HomeName = "Test Home",
                AvailableSlots = new HashSet<DateTime> { startDate, endDate }
            }
        };

            _repositoryMock
                .Setup(repo => repo.GetAsync(It.IsAny<Func<Home, bool>>()))
                .ReturnsAsync((Func<Home, bool> filter) => homes.FindAll(h => filter(h)));

            var expectedMapped = new List<AvailableHomeResponse>
        {
            new AvailableHomeResponse
            {
                HomeId = "1",
                HomeName = "Test Home",
                AvailableSlots = new List<DateTime> { startDate, endDate }
            }
        };

            _mapperMock
                .Setup(mapper => mapper.Map<List<AvailableHomeResponse>>(It.IsAny<List<Home>>()))
                .Returns(expectedMapped);

            var result = await _homeService.GetAvailableHomeAsync(startDate, endDate);

            Assert.NotNull(result);
            Assert.Single(result.Homes);
            Assert.Equal("1", result.Homes[0].HomeId);
            Assert.Equal(2, result.Homes[0].AvailableSlots.Count);
        }

        [Fact]
        public async Task GetAvailableHomeAsync_StartDateGreaterThanEndDate_ReturnsEmptyList()
        {
            var startDate = new DateTime(2025, 7, 22);
            var endDate = new DateTime(2025, 7, 20);

            var homes = new List<Home>();

            _repositoryMock
                .Setup(repo => repo.GetAsync(It.IsAny<Func<Home, bool>>()))
                .ReturnsAsync(homes);

            _mapperMock
                .Setup(mapper => mapper.Map<List<AvailableHomeResponse>>(It.IsAny<List<Home>>()))
                .Returns(new List<AvailableHomeResponse>());

            var result = await _homeService.GetAvailableHomeAsync(startDate, endDate);

            Assert.NotNull(result);
            Assert.Empty(result.Homes);
        }
    }
}

