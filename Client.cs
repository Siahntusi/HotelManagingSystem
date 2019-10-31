using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF_SERVICE_CLIENT
{
   [DataContract]
    class Client :BaseUser
    {
        private string paymentType;
        private int cityID;

        [DataMember(Name = "PaymentType")]
        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }

        [DataMember(Name = "CityID")]
        public int CityID
        {
            get { return cityID; }
            set { cityID = value; }
        }
    }
}
