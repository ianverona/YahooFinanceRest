using System;

namespace YahooFinance
{
    public interface IShouldFetchConstraint
    {
        bool ShouldFetch(DateTime fetchTime);
    }

    public class CopenhagenExchangeTradeConstraint : IShouldFetchConstraint
    {
        public bool ShouldFetch(DateTime fetchTime)
        {
            var now = fetchTime;

            // Dont fetch in weekends
            if (now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
                return false;

            return now.Hour >= 9 && now.TimeOfDay < new TimeSpan(21, 0, 0);
        }
    }
}