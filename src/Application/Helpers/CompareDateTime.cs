namespace Application.Helpers
{
    public static class CompareDateTime
    {
        public static int CompareDates(DateTime date1, DateTime date2)
        {
            var dateTime1 = date1.Ticks;
            var dateTime2 = date2.Ticks;
            if (dateTime1 < dateTime2)
                return -1;
            else
                return 1;

        }
    }
}
