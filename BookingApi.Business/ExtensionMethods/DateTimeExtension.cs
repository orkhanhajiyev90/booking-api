namespace BookingApi.Business.ExtensionMethods
{
    public static class DateTimeExtension
    {
        public static IEnumerable<DateTime> GetDateRange(this DateTime startDate, DateTime endDate)
        {
            for (var date = startDate.Date; date <= endDate.Date; date = date.Date.AddDays(1))
                yield return date.Date;
        }
    }
}
