using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
    public class BookingDuration
    {
        public static DateTime computeDuration(string start)
        {
            start = DateTime.Now.ToString();
            DateTime startDate = Convert.ToDateTime(start);
            DateTime end = startDate.AddDays(9.0);

            return end;
        }
    }
}