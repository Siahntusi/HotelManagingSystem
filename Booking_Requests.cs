using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
   public  class Booking_Requests
    {
        

        public int StudId
        {
            set;
            get;
        }

        public int AccommoId
        {
            set;
            get;
        }

        public string BookingStatus
        {
            set;
            get;
        }

    }
}
