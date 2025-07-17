using BookingApi.Core.Entities;

namespace BookingApi.Data
{
    public static class InMemoryHomeStorage
    {
        public static Dictionary<string, Home> Homes { get; set; } = new Dictionary<string, Home>()
        {
            {
               "1", new Home
                {
                    HomeId = "1",
                    HomeName = "Home_1",
                    AvailableSlots = new HashSet<DateTime>
                    {
                        new DateTime(2025, 7, 20),
                        new DateTime(2025, 7, 21),
                        new DateTime(2025, 7, 22),
                        new DateTime(2025, 7, 23)
                    }
                }
            },
            {
              "2",  new Home
                {
                    HomeId = "2",
                    HomeName = "Home_2",
                    AvailableSlots = new HashSet<DateTime>
                    {
                        new DateTime(2025, 7, 25),
                        new DateTime(2025, 7, 26),
                        new DateTime(2025, 7, 27)
                    }
                }
            },
            {
               "3", new Home
                {
                    HomeId = "3",
                    HomeName = "Home_3",
                    AvailableSlots = new HashSet<DateTime>
                    {
                        new DateTime(2025, 7, 16),
                        new DateTime(2025, 7, 17),
                        new DateTime(2025, 7, 20),
                        new DateTime(2025, 7, 21)
                    }
                }
            },
            {
              "4",  new Home
                {
                    HomeId = "4",
                    HomeName = "Home_4",
                    AvailableSlots = new HashSet<DateTime>
                    {
                        new DateTime(2025, 7, 22),
                        new DateTime(2025, 7, 23),
                        new DateTime(2025, 7, 24),
                        new DateTime(2025, 7, 25),
                        new DateTime(2025, 7, 26)
                    }
                }
            },
            {
              "5",  new Home
                {
                    HomeId = "5",
                    HomeName = "Home_5",
                    AvailableSlots = new HashSet<DateTime>
                    {
                        new DateTime(2025, 7, 28),
                        new DateTime(2025, 7, 29),
                        new DateTime(2025, 7, 30)
                    }
                }
            }
        };
    }
}

