using BookingApi.Business.Concrete;
using BookingApi.Core.Entities;
using Xunit;

namespace BookingApi.Tests
{
    public class AvailableHomesTests
    {
        private readonly HomeService _homeService;
        public AvailableHomesTests()
        {
            var fakeRepo = new FakeHomeRepository();

            fakeRepo.AddRange(new List<Home>
        {
            new Home
            {
                HomeId = "A1",
                HomeName = "Test Home 1",
                AvailableSlots = new HashSet<DateTime>
                {
                    new DateTime(2025, 7, 15),
                    new DateTime(2025, 7, 16),
                    new DateTime(2025, 7, 17)
                }
            },
            new Home
            {
                HomeId = "A2",
                HomeName = "Test Home 2",
                AvailableSlots = new HashSet<DateTime>
                {
                    new DateTime(2025, 7, 17),
                    new DateTime(2025, 7, 18)
                }
            }
        });

            _homeService = new HomeService(fakeRepo);
        }

        [Fact]
        public async Task GetAvailableHomesAsync_Should_Return_Only_Matching_Homes()
        {
            // Arrange
            var startDate = new DateTime(2025, 7, 15);
            var endDate = new DateTime(2025, 7, 16);

            // Act
            var result = await _homeService.GetAvailableHomeAsync(startDate, endDate);

            // Assert
            Assert.Single(result.Homes);
            Assert.Equal("A1", result.Homes[0].HomeId);
            Assert.Contains(startDate, result.Homes[0].AvailableSlots);
            Assert.Contains(endDate, result.Homes[0].AvailableSlots);
        }

        [Fact]
        public async Task GetAvailableHomesAsync_Should_Return_Empty_When_StartDate_Greater_Than_EndDate()
        {
            var startDate = new DateTime(2025, 7, 18);
            var endDate = new DateTime(2025, 7, 15);

            var result = await _homeService.GetAvailableHomeAsync(startDate, endDate);

            Assert.Empty(result.Homes);
        }
    }
}

