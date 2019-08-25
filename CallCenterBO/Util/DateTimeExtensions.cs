using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Util
{
    public static class DateTimeExtensions
    {
        public static DateTime GetMondayDateTime(this DateTime date)
        {
            DateTime diaActual = DateTime.Now;
            switch (diaActual.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return new DateTime(date.Year, date.Month, date.Day);
                case DayOfWeek.Tuesday:
                    return (new DateTime(date.Year, date.Month, date.Day)).AddDays(-1);
                case DayOfWeek.Wednesday:
                    return (new DateTime(date.Year, date.Month, date.Day)).AddDays(-2);
                case DayOfWeek.Thursday:
                    return (new DateTime(date.Year, date.Month, date.Day)).AddDays(-3);
                case DayOfWeek.Friday:
                    return (new DateTime(date.Year, date.Month, date.Day)).AddDays(-4);
                case DayOfWeek.Saturday:
                    return (new DateTime(date.Year, date.Month, date.Day)).AddDays(-5);
                case DayOfWeek.Sunday:
                    return (new DateTime(date.Year, date.Month, date.Day)).AddDays(-6);
                default:
                    return date;
            }
           
        }
    }
}
