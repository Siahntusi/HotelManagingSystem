using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
    public class BookingsConsolidator
    {
        List<Booking> bookings;

        public List<Booking> Bookings
        {
            get { return bookings; }
            set { bookings = value; }
        }
    }
}