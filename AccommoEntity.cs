using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
    public class AccommoEntity
    {
        public int OwnerID
        {
            set;
            get;
        }

        public int AccommoID
        {
            set;
            get;
        }
        public string AccommoName
        {
            set;
            get;
        }
        public int AddressId
        {
            set;
            get;
        }
        public decimal Distance
        {
            set;
            get;
        }
        public string NearestCampus
        {
            set;
            get;
        }
        public int Capacity
        {
            set;
            get;
        }
        public string AccredStatus
        {
            set;
            get;
        }
        public string StartDate
        {
            set;
            get;
        }
        public string EndDate
        {
            set;
            get;
        }
        public string AccommoType
        {
            get;
            set;
        }
    }
}
