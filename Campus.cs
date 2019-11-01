using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCF_SERVICE_CLIENT_HOST.Models
{
    [DataContract]
    public class Campus
    {
        private int campusID;
        private string campusName;
        private string campusAbbrev;
        private Address campusAddress;

        [DataMember]
        public int CampusID
        {
            get { return campusID; }
            set { campusID = value; }
        }
        [DataMember]
        public string CampusName
        {
            get { return campusName; }
            set { campusName = value; }
        }
        [DataMember]
        public string CampusAbbrev
        {
            get { return campusAbbrev; }
            set { campusAbbrev = value; }
        }
        [DataMember]
        public Address CampusAddress
        {
            get { return campusAddress; }
            set { campusAddress = value; }
        }

    }
}