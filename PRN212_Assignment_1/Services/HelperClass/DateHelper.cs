﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.HelperClass
{
    public static class DateHelper
    {
        // Convert DateOnly? to DateTime?
        public static DateTime? FromDateOnlyToDateTime(this DateOnly? dateOnly)
        {
            if (dateOnly.HasValue)
            {
                return new DateTime(dateOnly.Value.Year, dateOnly.Value.Month, dateOnly.Value.Day);
            }
            return null;
        }

        // Convert DateTime? to DateOnly?
        public static DateOnly? FromDateTimeToDateOnly(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return DateOnly.FromDateTime(dateTime.Value);
            }
            return null;
        }
    }
}
