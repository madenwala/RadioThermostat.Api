using RadioThermostat.Api.Models;
using System;

internal static class DateTimeHelper
{
    internal static RadioThermostat.Api.Models.Days ConvertDateTimeDayOfWeek(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Sunday: return Days.Sunday;
            case DayOfWeek.Monday: return Days.Monday;
            case DayOfWeek.Tuesday: return Days.Tuesday;
            case DayOfWeek.Wednesday: return Days.Wednesday;
            case DayOfWeek.Thursday: return Days.Thursday;
            case DayOfWeek.Friday: return Days.Friday;
            case DayOfWeek.Saturday: return Days.Saturday;

            default: throw new NotImplementedException();
        }
    }
}
